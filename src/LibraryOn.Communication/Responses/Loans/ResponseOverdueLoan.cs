using LibraryOn.Communication.Enums.Loan;

namespace LibraryOn.Communication.Responses.Loans;
public class ResponseOverdueLoan
{
    public long Id { get; set; }
    public LoanStatus Status { get; set; }
    public DateOnly DueDate { get; set; }
    public string ReaderName { get; set; } = string.Empty;
    public string BookTitle { get; set; } = string.Empty;
    public int DaysOverdue { get; set; }
}
