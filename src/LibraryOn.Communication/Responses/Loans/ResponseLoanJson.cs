using LibraryOn.Communication.Enums.Loan;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Communication.Responses.Employee;
using LibraryOn.Communication.Responses.Readers;

namespace LibraryOn.Communication.Responses.Loans;
public class ResponseLoanJson
{
    public long Id { get; set; }
    public ResponseBookJson? Book { get; set; }
    public ResponseReaderJson? Reader { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime LoanDate { get; set; }
    public LoanStatus Status { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public ResponseEmployeeJson? Employee { get; set; }
}
