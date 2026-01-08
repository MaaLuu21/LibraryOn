using AutoMapper;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Genres.Update;
public class UpdateGenreUseCase : IUpdateGenreUseCase
{
    private readonly IGenresUpdateOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public UpdateGenreUseCase(IGenresUpdateOnlyRepository repository,
                              IUnityOfWork unityOfWork,
                              IMapper mapper)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task Execute(long id, RequestGenreJson request)
    {
        Validate(request);

        var genre = await _repository.GetById(id);
        if(genre == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.GENRE_NOT_FOUND);
        }

        _mapper.Map(request, genre);

        _repository.Update(genre);

        await _unityOfWork.Commit();

    }

    private void Validate(RequestGenreJson request)
    {
        var validator = new GenreValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }
    }
}
