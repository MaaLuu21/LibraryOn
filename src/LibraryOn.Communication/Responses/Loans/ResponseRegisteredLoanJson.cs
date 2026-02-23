namespace LibraryOn.Communication.Responses.Loans
{
    public class ResponseRegisteredLoanJson
    {
        public long Id { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime LoanDate { get; private set; }
    }
}
