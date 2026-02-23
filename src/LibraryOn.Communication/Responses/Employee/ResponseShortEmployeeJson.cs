using LibraryOn.Communication.Enums.Employee;
using LibraryOn.Communication.Responses.Loans;

namespace LibraryOn.Communication.Responses.Employee;
public class ResponseShortEmployeeJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.EMPLOYEE;
}
