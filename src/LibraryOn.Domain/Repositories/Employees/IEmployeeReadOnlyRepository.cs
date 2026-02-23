namespace LibraryOn.Domain.Repositories.Employees;
public interface IEmployeeReadOnlyRepository
{
    Task<bool> ExistActiveEmployeeWithEmail(string email);
    Task<Entities.Employee?> GetEmployeeByEmail(string email);
    Task<Entities.Employee?> GetById(long id);
    Task<List<Entities.Employee>> GetAll();

}
