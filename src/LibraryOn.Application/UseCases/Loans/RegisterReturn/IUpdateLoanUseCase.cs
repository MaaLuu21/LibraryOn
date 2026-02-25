using LibraryOn.Communication.Requests.Loans;

namespace LibraryOn.Application.UseCases.Loans.RegisterReturn;
public interface RegisterLoanReturnUseCase
{
    Task Execute(RequestLoanReturnJson request);
}
