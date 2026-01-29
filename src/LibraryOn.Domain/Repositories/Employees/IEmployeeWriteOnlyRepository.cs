using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Employees;
public interface IEmployeeWriteOnlyRepository
{
    Task Add(Employee employee);
}
