
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.Delete;
public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBookReadOnlyRepository _readRepository; 
    private readonly IBookWriteOnlyRepository _writeRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteBookUseCase(IBookReadOnlyRepository readRepository,
                             IBookWriteOnlyRepository writeRepository,
                             IUnityOfWork unityOfWork)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task Execute(long id)
    {
        var book = await _readRepository.GetById(id);

        if(book == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        _writeRepository.Delete(book);
        await _unityOfWork.Commit();

    }
}
