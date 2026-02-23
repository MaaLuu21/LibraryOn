using AutoMapper;
using LibraryOn.Domain.Enums;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Security.Cryptography;

namespace LibraryOn.Application.UseCases.Employee.Register.Manager;
public class RegisterManagerUseCase : RegisterEmployeeBaseUseCase, IRegisterManagerUseCase
{
    protected override string Role => Roles.MANAGER;

    public RegisterManagerUseCase(IEmployeeWriteOnlyRepository writeRepository,
                            IEmployeeReadOnlyRepository readRepository,
                            IUnityOfWork unityOfWork,
                            IPasswordEncripter encripter,
                            IMapper mapper)
    : base(writeRepository, readRepository, unityOfWork, encripter, mapper) { }
}
