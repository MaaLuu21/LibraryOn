using AutoMapper;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Domain.Services.LoggedEmployee;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.Register;
public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBookWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IGenresReadOnlyRepository _genreRepository;
    private readonly IMapper _mapper;

    public RegisterBookUseCase(IBookWriteOnlyRepository repository,
                               IUnityOfWork unityOfWork,
                               IMapper mapper, 
                               IGenresReadOnlyRepository genreRepository)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _genreRepository = genreRepository;
    }

    public async Task<ResponseRegisteredBookJson> Execute(RequestBookJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Book>(request);

        var genres = await _genreRepository.GetByIds(request.GenreIds);

        if (genres == null || genres.Count == 0)
        {
            throw new NotFoundExecption(ResourceErrorMessages.GENRE_NOT_FOUND);
        }

        foreach (Genre genre in genres)
        {
            entity.Genres.Add(genre);
        }

        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredBookJson>(entity);
    }

    private void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
