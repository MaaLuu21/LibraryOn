using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;
using System.Reflection.Metadata.Ecma335;

namespace LibraryOn.Domain.Entities;
public class Loan
{
    private const int DefaultLoanDays = 7;

    public long Id  { get; set; }
    public Book? Book { get; set; }
    public Reader? Reader { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime LoanDate { get; set; }
    public LoanStatus Status { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public Employee Employee { get; set; }
    public int DaysOverdue { get; set; }

    protected Loan() { }

    public Loan(Book book, Reader reader, Employee employee)
    {
        Book = book ?? throw new DomainException(DomainErrorCodes.BookRequired);
        Reader = reader ?? throw new DomainException(DomainErrorCodes.ReaderRequired);
        Employee = employee ?? throw new DomainException(DomainErrorCodes.EmployeeRequired);

        LoanDate = DateTime.UtcNow;
        DueDate = LoanDate.AddDays(DefaultLoanDays);
        Status = LoanStatus.Active;
    }

    public bool IsOverdue()
    {
        if(Status == LoanStatus.Active || Status == LoanStatus.Overdue && DateTime.UtcNow > DueDate)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateDaysOverdue()
    {
        if (DateTime.UtcNow > DueDate)
        {
            var diferenca = DateTime.UtcNow - DueDate;
            DaysOverdue = diferenca.Days;
        } 
        else 
        { 
            DaysOverdue = 0; 
        } 
    }
}
