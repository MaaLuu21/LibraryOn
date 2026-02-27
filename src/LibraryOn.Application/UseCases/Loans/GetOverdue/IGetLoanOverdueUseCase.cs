using LibraryOn.Communication.Responses.Loans;

namespace LibraryOn.Application.UseCases.Loans.GetOverdue;
public interface IGetLoanOverdueUseCase
{
    Task<List<ResponseOverdueLoan>> Execute();
}
