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
    public Email Email { get; private set; }
    public Cpf Cpf { get; private set; }
    public ICollection<Loan> Loans { get; set; }

    protected Reader() { }

    public Reader(PhoneNumber phoneNumber,
                  Email email, Cpf cpf)
    {
        PhoneNumber = phoneNumber;
        Email = email;
        Cpf = cpf;
    }

    public Loan BorrowBook(Book book, DateTime loanDate)
    {
        if(Loans.Count(l => l.Status == LoanStatus.Active) >= MaxLoan)
        {
            throw new DomainException(DomainErrorCodes.LimitLoans);
        }

        var loan = new Loan(book, this, loanDate);
        Loans.Add(loan);
        return loan;
    }

}
