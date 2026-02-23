using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Employee.Register.Manager;
public interface IRegisterManagerUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestRegisterEmployeeJson request);
}
