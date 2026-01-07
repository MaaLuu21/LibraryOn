using System.Net;

namespace LibraryOn.Exception.ExceptionsBase;
public class NotFoundExecption : LibraryOnException
{
    public NotFoundExecption(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

}
