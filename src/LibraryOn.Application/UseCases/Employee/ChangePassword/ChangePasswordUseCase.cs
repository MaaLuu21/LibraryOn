using FluentValidation.Results;
using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Security.Cryptography;
using LibraryOn.Domain.Services.LoggedEmployee;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Employee.ChangePassword;
public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly ILoggedEmployee _loggedEmployee;
    private readonly IEmployeeUpdateOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IPasswordEncripter _passwordEncripter;

    public ChangePasswordUseCase(ILoggedEmployee loggedEmployee,
                                 IEmployeeUpdateOnlyRepository repository,
                                 IUnityOfWork unityOfWork,
                                 IPasswordEncripter passwordEncripter)
    {
        _loggedEmployee = loggedEmployee;
        _repository = repository;
        _unityOfWork = unityOfWork;
        _passwordEncripter = passwordEncripter;
    }

    public async Task Execute(RequestChangePasswordJson request)
    {
        var loggedEmployee = await _loggedEmployee.Get();

        Validate(request, loggedEmployee);

        var employee = await _repository.GetById(loggedEmployee.Id);
        employee.Password = _passwordEncripter.Encripty(request.NewPassword);

        _repository.Update(employee);
        await _unityOfWork.Commit();

    }

    private void Validate(RequestChangePasswordJson request, LibraryOn.Domain.Entities.Employee loggedEmployee)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(request);

        var passwordMatch = _passwordEncripter.Verify(request.Password, loggedEmployee.Password);

        if(passwordMatch == false)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFFEERENT_THEN_CURRENT));
        }

        if(result.IsValid == false)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }

    }
}
