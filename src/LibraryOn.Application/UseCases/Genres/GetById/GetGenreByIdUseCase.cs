using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Genres.GetById;
public class GetGenreByIdUseCase : IGetGenreByIdUseCase
{
    private readonly IGenresReadOnlyRepository _repository;

    public GetGenreByIdUseCase(IGenresReadOnlyRepository repository)
    {
        _repository = repository;        
    }

    public async Task<ResponseGenreJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if(result == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.GENRE_NOT_FOUND);
        }

        return new ResponseGenreJson
        {
            Id = result.Id,
            Name = result.Name
        };

    }
}
