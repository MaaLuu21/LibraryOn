namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoanReadOnlyRepository
{
    Task<Entities.Loan?> GetActiveLoan(long id, string cpf);
    Task<Entities.Loan?> GetById(long loanId);
    Task<List<Entities.Loan>> GetOverdueLoans();
    Task UpdatePendingOverdueLoans();
    Task<List<Entities.Loan>> GetAll();
}
