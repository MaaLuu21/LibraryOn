
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Genres.Delete;
public class DeleteGenreUseCase : IDeleteGenreUseCase
{
    private readonly IGenresWriteOnlyRepository _writeRepository;
    private readonly IGenresReadOnlyRepository _readRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteGenreUseCase(IGenresWriteOnlyRepository writeRepository,
                              IGenresReadOnlyRepository readRepository,
                              IUnityOfWork unitOfWork)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unityOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var genre = await _readRepository.GetById(id);

        if(genre == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.GENRE_NOT_FOUND);
        }

        _writeRepository.Delete(genre);
        await _unityOfWork.Commit();

    }
}
