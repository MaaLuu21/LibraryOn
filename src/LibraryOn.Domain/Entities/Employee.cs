using LibraryOn.Domain.Enums;
using LibraryOn.Domain.ValueObjects;

namespace LibraryOn.Domain.Entities;
public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Email Email { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public Role Role { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Loan?> Loans { get; set; } = [];

    public Employee() { }

    public Employee(Email email)
    {
        Email = email;
    }

}
