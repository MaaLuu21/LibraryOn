using System.Data;

namespace LibraryOn.Communication.Requests.Employee;
public class RequestRegisterEmployeeJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}
