using LibraryOn.Domain.Enums;
using LibraryOn.Domain.ValueObjects;

namespace LibraryOn.Domain.Entities;
public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.EMPLOYEE;
    public ICollection<Loan?> Loans { get; set; } = [];
    public Guid EmployeeIdentifier { get; set; }
     
    public Employee() { }


}
