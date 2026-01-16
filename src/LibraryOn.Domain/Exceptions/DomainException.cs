namespace LibraryOn.Domain.Exceptions;
public class DomainException : Exception
{
    public List<string> ErrorCodes { get; }

    public DomainException(string errorCode)
    {
        ErrorCodes = new List<string> { errorCode };
    }
    public DomainException(IEnumerable<string> errorCodes)
    {
        ErrorCodes = errorCodes.ToList();
    }
}
