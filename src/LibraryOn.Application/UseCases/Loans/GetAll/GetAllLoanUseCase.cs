using AutoMapper;
using LibraryOn.Communication.Responses.Loans;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Loans.GetAll;
public class GetAllLoanUseCase : IGetAllLoanUseCase
{

    private readonly ILoanReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllLoanUseCase(ILoanReadOnlyRepository repository,
                             IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseLoansJson> Execute()
    {
        var loan = await _repository.GetAll();

        if(loan == null || loan.Count == 0)
        {
            throw new NotFoundException(ResourceErrorMessages.LOAN_NOT_FOUND);
        }

        return new ResponseLoansJson
        {
            Loans = _mapper.Map<List<ResponseShortLoanJson>>(loan)
        };
    }
}
