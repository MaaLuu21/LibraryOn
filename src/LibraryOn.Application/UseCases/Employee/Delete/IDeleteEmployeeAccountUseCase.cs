namespace LibraryOn.Application.UseCases.Employee.Delete;
public interface IDeleteEmployeeAccountUseCase
{
    Task Execute(long id);
}
