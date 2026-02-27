using LibraryOn.Communication.Responses.Loans;
using LibraryOn.Domain.Entities;

namespace LibraryOn.Application.UseCases.Loans.GetAll;
public interface IGetLoanByIdUseCase
{
    Task<ResponseLoanJson> Execute(long id);
}
