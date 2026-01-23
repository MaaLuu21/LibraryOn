using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Loans;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class LoansRepository : ILoansWriteOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;
    public LoansRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Loan loan)
    {
        await _dbContext.Loans.AddAsync(loan);
    }
}
