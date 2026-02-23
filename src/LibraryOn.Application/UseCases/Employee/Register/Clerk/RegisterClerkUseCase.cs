using AutoMapper;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Security.Cryptography;

namespace LibraryOn.Application.UseCases.Employee.Register.Clerk;
public class RegisterClerkUseCase : RegisterEmployeeBaseUseCase, IRegisterClerkUseCase
{
    protected override string Role => Roles.CLERK;

    public RegisterClerkUseCase(IEmployeeWriteOnlyRepository writeRepository, 
                                IEmployeeReadOnlyRepository readRepository, 
                                IUnityOfWork unityOfWork, 
                                IPasswordEncripter encripter, 
                                IMapper mapper)
        : base(writeRepository, readRepository, unityOfWork, encripter, mapper) { }
}
