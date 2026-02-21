using LibraryOn.Communication.Requests.Employees;

namespace LibraryOn.Application.UseCases.Employee.ChangePassword;
public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}
