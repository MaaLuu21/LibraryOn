using LibraryOn.Communication.Enums.Employee;

namespace LibraryOn.Communication.Responses.Employee;
public class ResponseEmployeeJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.CLERK;
}
