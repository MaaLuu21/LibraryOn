using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Employee.Register;
public interface IRegisterEmployeeUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestRegisterEmployeeJson request);
}
