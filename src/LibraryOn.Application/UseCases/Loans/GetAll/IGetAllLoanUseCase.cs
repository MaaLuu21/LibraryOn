using LibraryOn.Domain.Entities;

namespace LibraryOn.Application.UseCases.Loans.GetAll;
public interface IGetAllLoanUseCase
{
    Task<List<Loan>> Execute();
}
