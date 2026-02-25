using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoanWriteOnlyRepository
{
    Task Add(Loan loan);
    Task<bool> HasActiveLoanForBook(long bookId);
    Task<int> CountActiveLoansByReader(long readerId);
}
