using AutoMapper;
using LibraryOn.Communication.Responses.Loans;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Loans.GetOverdue;
public class GetLoanOverdueUseCase : IGetLoanOverdueUseCase
{
    private readonly ILoanReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetLoanOverdueUseCase(ILoanReadOnlyRepository repository,
                                 IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<ResponseOverdueLoan>> Execute()
    {
        await _repository.UpdatePendingOverdueLoans();

        var result = await _repository.GetOverdueLoans();

        if(result == null || result.Count == 0)
        {
            throw new NotFoundException(ResourceErrorMessages.NO_ORVERDUE_LOAN_FOUND);
        }

        return _mapper.Map<List<ResponseOverdueLoan>>(result);
    }
}
