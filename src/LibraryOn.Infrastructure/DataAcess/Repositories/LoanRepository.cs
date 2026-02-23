using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Loans;
using Microsoft.EntityFrameworkCore;

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
        _dbContext.Entry(loan.Book!).State = EntityState.Unchanged;
        _dbContext.Entry(loan.Reader!).State = EntityState.Unchanged;
        _dbContext.Entry(loan.Employee).State = EntityState.Unchanged;

        await _dbContext.Loans.AddAsync(loan);
    }
}
