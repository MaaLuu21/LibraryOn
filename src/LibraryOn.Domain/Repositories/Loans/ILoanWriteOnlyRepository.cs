using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoanWriteOnlyRepository
{
    Task Add(Loan loan);
}
