using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;
using LibraryOn.Domain.ValueObjects;

namespace LibraryOn.Domain.Entities;
public class Reader
{
    private const int MaxLoan = 2;

    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; set; } = string.Empty;
    public Cpf Cpf { get; private set; }
    public ICollection<Loan> Loans { get; set; } = [];

    protected Reader() { }

    public Reader(PhoneNumber phoneNumber, Cpf cpf)
    {
        PhoneNumber = phoneNumber;
        Cpf = cpf;
    }

    public Loan BorrowBook(Book book, Employee employee, DateTime loanDate)
    {
        if(Loans.Count(l => l.Status == LoanStatus.Active) >= MaxLoan)
        {
            throw new DomainException(DomainErrorCodes.LimitLoans);
        }

        var loan = new Loan(book, this, employee, loanDate);
        Loans.Add(loan);
        return loan;
    }

}
