namespace LibraryOn.Communication.Responses.Readers;
public class ResponseReaderJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}
