using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Domain.Repositories.Loans;
public interface ILoanReadOnlyRepository
{
    Task<Entities.Loan?> GetActiveLoan(long bookId, string cpf);
}
