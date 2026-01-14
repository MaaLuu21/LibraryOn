using AutoMapper;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.Update;
public class UpdateBookUseCase : IUpdateBookUseCase
{
    private readonly IBookUpdateOnlyRepository _bookRepository;
    private readonly IGenresReadOnlyRepository _genresRepository;
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateBookUseCase(IBookUpdateOnlyRepository bookRepository,
                             IMapper mapper,
                             IUnityOfWork unityOfWork,
                             IGenresReadOnlyRepository genresRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _genresRepository = genresRepository;
    }

    public async Task Execute(long id, RequestBookJson request)
    {
        Validate(request);

        var book = await _bookRepository.GetById(id);

        if (book == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.BOOK_NOT_FOUND);
        }

        _mapper.Map(request, book);

        book.Genres.Clear();

        var genres = await _genresRepository.GetByIds(request.GenreIds);
        
        foreach ( var genre in genres)
        {
            book.Genres.Add(genre);
        }

        _bookRepository.Update(book);

        await _unityOfWork.Commit();

    }

    private void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }



    }
}
