using LibraryOn.Communication.Responses.Loans;

namespace LibraryOn.Application.UseCases.Loans.GetAll;
public interface IGetAllLoanUseCase
{
    Task<ResponseLoansJson> Execute();
}
