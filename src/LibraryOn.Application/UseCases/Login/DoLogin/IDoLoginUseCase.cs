using LibraryOn.Communication.Requests.Employee;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestLoginJson request);
}
