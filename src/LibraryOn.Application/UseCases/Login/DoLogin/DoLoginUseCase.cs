using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Security.Cryptography;
using LibraryOn.Domain.Security.Tokens;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Login.DoLogin;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;


    public DoLoginUseCase(IEmployeeReadOnlyRepository repository,
                          IPasswordEncripter passwordEncripter,
                          IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerator = accessTokenGenerator;

    }

    public async Task<ResponseRegisteredEmployeeJson> Execute(RequestLoginJson request)
    {
        var employee = await _repository.GetEmployeeByEmail(request.Email);

        if(employee == null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch =  _passwordEncripter.Verify(request.Password, employee.Password);

        if(passwordMatch == false)
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredEmployeeJson
        {
            Name = employee.Name,
            Token = _accessTokenGenerator.Generate(employee)
        };
    }
}
