namespace LibraryOn.Domain.Exceptions;
public class DomainException : Exception
{
    public string ErrorCode { get; }

    protected DomainException(string errorCode)
    {
        ErrorCode = errorCode;
    }

}
