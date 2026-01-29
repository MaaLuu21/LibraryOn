using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Loans;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class LoanRepository : ILoanWriteOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;
    public LoanRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Loan loan)
    {
        await _dbContext.Loans.AddAsync(loan);
    }
}
