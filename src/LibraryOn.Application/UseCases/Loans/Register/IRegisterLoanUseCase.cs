using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Communication.Responses.Loans;

namespace LibraryOn.Application.UseCases.Loans.Register;
public interface IRegisterLoanUseCase
{
    Task<ResponseRegisteredLoanJson> Execute(RequestLoanJson request);
}
