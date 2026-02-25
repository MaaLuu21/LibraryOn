using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Repositories.Loans;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class LoanRepository : ILoanWriteOnlyRepository, ILoanReadOnlyRepository, ILoanUpdateOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;
    public LoanRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CountActiveLoansByReader(long readerId) 
    { 
        return await _dbContext.Loans.CountAsync(l => l.Reader!.Id == readerId && l.Status == LoanStatus.Active); 
    } 

    public async Task<bool> HasActiveLoanForBook(long bookId) 
    { 
        return await _dbContext.Loans.AnyAsync(l => l.Book!.Id == bookId && l.Status == LoanStatus.Active); 
    }

    public async Task Add(Loan loan)
    {
        _dbContext.Entry(loan.Book!).State = EntityState.Unchanged;
        _dbContext.Entry(loan.Reader!).State = EntityState.Unchanged;
        _dbContext.Entry(loan.Employee).State = EntityState.Unchanged;

        await _dbContext.Loans.AddAsync(loan);
    }

    public async Task<Loan?> GetActiveLoan(long bookId, string cpf)
    {
        return await _dbContext.Loans
            .Include(l =>  l.Book)
            .Include(l => l.Reader)
            .FirstOrDefaultAsync(l => l.Book!.Id == bookId
                                && l.Reader!.Cpf.Value == cpf
                                && l.Status == LoanStatus.Active);
    }

    public void Update(Loan loan)
    {
        _dbContext.Loans.Update(loan);
    }
}
