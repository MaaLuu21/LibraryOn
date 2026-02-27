using System.Net;

namespace LibraryOn.Exception.ExceptionsBase;
public class NotFoundException : LibraryOnException
{
    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

}
