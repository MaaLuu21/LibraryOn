using LibraryOn.Application.UseCases.Loans.Update;
using LibraryOn.Communication.Enums.Loan;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Loans.RegisterReturn;
public class UpdateLoanUseCase : IUpdateLoanUseCase
{
    private readonly ILoanUpdateOnlyRepository _updateRepository;
    private readonly ILoanReadOnlyRepository _readRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateLoanUseCase(ILoanUpdateOnlyRepository updateRepository,
                             ILoanReadOnlyRepository readRepository,
                             IUnityOfWork unityOfWork)
    {
        _updateRepository = updateRepository;
        _readRepository = readRepository;
        _unityOfWork = unityOfWork;
    }

    public async  Task Execute(RequestLoanUpdateJson request)
    {
        Validate(request);

        var loan = await _readRepository.GetActiveLoan(request.LoanId, request.Cpf);

        if(loan == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.LOAN_NOT_FOUND_OR_ALREADY_RETURNED);
        }

        loan.Status = Domain.Enums.LoanStatus.Returned;
        loan.ReturnedAt = request.ReturnedAt;

        _updateRepository.Update(loan);
        await _unityOfWork.Commit();
        
    }

    private void Validate(RequestLoanUpdateJson request)
    {
        var validate = new UpdateLoanValidator();

        var result = validate.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
