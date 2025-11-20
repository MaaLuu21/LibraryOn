namespace LibraryOn.Exception.ExceptionsBase;
public abstract class LibraryOnException : SystemException
{
    protected LibraryOnException(string message) : base(message) { }

    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();

}
