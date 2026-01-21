
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Readers.Delete;
public class DeleteReaderUseCase : IDeleteReaderUseCase
{
    private readonly IReaderWriteOnlyRepository _writeRepository;
    private readonly IReaderReadOnlyRepository _readRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteReaderUseCase(IReaderWriteOnlyRepository writeRepository,
                               IReaderReadOnlyRepository readRepository,
                               IUnityOfWork unityOfWork)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unityOfWork = unityOfWork; 
    }

    public async Task Execute(long id)
    {
        var reader = await _readRepository.GetById(id);

        if(reader == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.READER_NOT_FOUND);
        }

        _writeRepository.Delete(reader);
        await _unityOfWork.Commit();

    }
}
