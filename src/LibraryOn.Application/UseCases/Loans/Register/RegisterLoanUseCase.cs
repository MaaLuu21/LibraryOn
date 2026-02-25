using AutoMapper;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Communication.Responses.Loans;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Domain.Services.LoggedEmployee;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Loans.Register;
public class RegisterLoanUseCase : IRegisterLoanUseCase
{
    private readonly ILoanWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IBookReadOnlyRepository _bookRepository;
    private readonly IReaderReadOnlyRepository _readerRepository;
    private readonly IMapper _mapper;
    private readonly ILoggedEmployee _loggedEmployee;

    private const int MaxLoan = 2;

    public RegisterLoanUseCase(ILoanWriteOnlyRepository repository,
                               IUnityOfWork unityOfWork,
                               IBookReadOnlyRepository bookRepository,
                               IReaderReadOnlyRepository readerRepository,
                               IMapper mapper,
                               ILoggedEmployee loggedEmployee)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
        _mapper = mapper;
        _loggedEmployee = loggedEmployee;
    }

    public async Task<ResponseRegisteredLoanJson> Execute(RequestLoanJson request)
    {
        Validate(request);

        var book = await _bookRepository.GetById(request.BookId);
        if (book == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        var reader = await _readerRepository.GetByCpf(request.Cpf);
        if (reader == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.READER_NOT_FOUND);
        }

        var activeLoansCount = await _repository.CountActiveLoansByReader(reader.Id);
        if (activeLoansCount >= MaxLoan)
        {
            throw new NotAvailableException(ResourceErrorMessages.NUMBER_OF_BOOK_LOANS_EXCEEDED);
        }

        var employee = await _loggedEmployee.Get();
        if(employee == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        var hasActiveLoan = await _repository.HasActiveLoanForBook(book.Id);
        if (hasActiveLoan)
        {
            throw new NotAvailableException(ResourceErrorMessages.BOOK_NOT_AVAILABLE);
        }

        var loan = new Loan(book, reader, employee);

        await _repository.Add(loan);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredLoanJson>(loan);
    }

    private void Validate(RequestLoanJson request)
    {
        var validator = new LoanValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

