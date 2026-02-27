using LibraryOn.Communication.Requests.Loans;

namespace LibraryOn.Application.UseCases.Loans.RegisterReturn;
public interface IUpdateLoanUseCase
{
    Task Execute(RequestLoanUpdateJson request, long id);
}
