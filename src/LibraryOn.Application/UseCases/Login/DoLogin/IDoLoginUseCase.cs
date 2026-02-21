using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestLoginJson request);
}
