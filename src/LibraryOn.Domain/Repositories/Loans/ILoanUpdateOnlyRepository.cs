using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoanUpdateOnlyRepository
{
    void Update(Loan loan);
}
