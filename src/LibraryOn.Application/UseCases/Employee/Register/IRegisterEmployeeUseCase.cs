using LibraryOn.Communication.Requests.Employee;
using LibraryOn.Communication.Responses.Employee;

namespace LibraryOn.Application.UseCases.Employee.Register;
public interface IRegisterEmployeeUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestRegisterEmployeeJson request);
}
