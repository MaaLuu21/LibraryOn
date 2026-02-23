using AutoMapper;
using FluentValidation.Results;
using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses.Employee;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Security.Cryptography;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Employee.Register;
public abstract class RegisterEmployeeBaseUseCase
{
    private readonly IEmployeeWriteOnlyRepository _writeRepository;
    private readonly IEmployeeReadOnlyRepository _readRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IPasswordEncripter _encripter;
    private readonly IMapper _mapper;

    protected abstract string Role { get; }

    public RegisterEmployeeBaseUseCase(IEmployeeWriteOnlyRepository writeRepository,
                                   IEmployeeReadOnlyRepository readRepository,
                                   IUnityOfWork unityOfWork,
                                   IPasswordEncripter encripter,
                                   IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unityOfWork = unityOfWork;
        _encripter = encripter;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredEmployeeJson> Execute(RequestRegisterEmployeeJson request)
    {
        await Validate(request);

        var employee = _mapper.Map<Domain.Entities.Employee>(request);

        employee.Password = _encripter.Encrypty(request.Password);
        employee.EmployeeIdentifier = Guid.NewGuid();
        employee.Role = Role;
        employee.MustChangePassword = true;

        await _writeRepository.Add(employee);
        await _unityOfWork.Commit();

        return new ResponseRegisteredEmployeeJson
        {
            Name = employee.Name,
        };

    }
    private async Task Validate(RequestRegisterEmployeeJson request)
    {
        var result = new RegisterEmployeeValidator().Validate(request);

        var emailExist = await _readRepository.ExistActiveEmployeeWithEmail(request.Email);

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }
    }
}
