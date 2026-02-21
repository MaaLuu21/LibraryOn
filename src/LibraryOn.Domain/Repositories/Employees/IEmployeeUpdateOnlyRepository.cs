namespace LibraryOn.Domain.Repositories.Employees;
public interface IEmployeeUpdateOnlyRepository
{
    Task<Entities.Employee> GetById(long id);

    void Update(Entities.Employee employee);
}
