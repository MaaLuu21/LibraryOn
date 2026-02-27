namespace LibraryOn.Communication.Requests.Loans;
public class RequestLoanUpdateJson
{
    public string Cpf { get; set; } = string.Empty;
    public DateTime ReturnedAt { get; set; }
}
