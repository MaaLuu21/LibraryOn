using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Employee.GetAll;
public interface IGetAllEmployeesUseCase
{
    Task<ResponseEmployeesJson> Execute();
}
