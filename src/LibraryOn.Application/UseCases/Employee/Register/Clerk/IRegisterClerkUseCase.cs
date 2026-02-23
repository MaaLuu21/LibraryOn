using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Employee.Register.Clerk;
public interface IRegisterClerkUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestRegisterEmployeeJson request);
}
