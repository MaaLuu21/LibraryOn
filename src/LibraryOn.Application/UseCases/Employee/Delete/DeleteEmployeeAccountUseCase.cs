
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Employee.Delete;
public class DeleteEmployeeAccountUseCase : IDeleteEmployeeAccountUseCase
{
    private readonly IEmployeeReadOnlyRepository _readRepository;
    private readonly IEmployeeWriteOnlyRepository _writeRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteEmployeeAccountUseCase(IEmployeeReadOnlyRepository readRepository,
                                        IEmployeeWriteOnlyRepository writeRepository,
                                        IUnityOfWork unityOfWork)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _unityOfWork = unityOfWork;
    }


    public async Task Execute(long id)
    {
        var employee = await _readRepository.GetById(id);

        if(employee == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        _writeRepository.Delete(employee);
        await _unityOfWork.Commit();
    }
}
