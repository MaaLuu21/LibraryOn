using LibraryOn.Communication.Enums.Loan;

namespace LibraryOn.Communication.Responses.Loans;
public class ResponseShortLoanJson
{
    public long Id { get; set; }
    public LoanStatus Status { get;  set; }
}
