namespace LibraryOn.Domain.Repositories.Employees;
public interface IEmployeeReadOnlyRepository
{
    Task<bool> ExistActiveEmployeeWithEmail(string email);
    Task<Entities.Employee?> GetEmployeeEmail(string email);

}
