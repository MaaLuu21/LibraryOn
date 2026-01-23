using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoansWriteOnlyRepository
{
    Task Add(Loan loan);
}
