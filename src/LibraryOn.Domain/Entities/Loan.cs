using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;

namespace LibraryOn.Domain.Entities;
public class Loan
{
    private const int DefaultLoanDays = 7;

    public long Id  { get; private set; }
    public Book? Book { get; private set; }
    public Reader? Reader { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime LoanDate { get; private set; }
    public LoanStatus Status { get; private set; }
    public DateTime? ReturnedAt { get; private set; }

    protected Loan() { }

    public Loan(Book book, Reader reader, DateTime loanDate)
    {
        Book = book ?? throw new DomainException(DomainErrorCodes.BookRequired);
        Reader = reader ?? throw new DomainException(DomainErrorCodes.ReaderRequired);

        LoanDate = loanDate;
        DueDate = loanDate.AddDays(DefaultLoanDays);
        Status = LoanStatus.Active;
    }

    public void ReturnBook(DateTime returnDate)
    {
        if(Status != LoanStatus.Active)
        {
            throw new DomainException(DomainErrorCodes.InvalidReturn);
        }

        ReturnedAt = returnDate;
        Status = LoanStatus.Returned;

    }

    public bool IsOverdue()
    {
        if(Status == LoanStatus.Active && DateTime.UtcNow > DueDate)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
