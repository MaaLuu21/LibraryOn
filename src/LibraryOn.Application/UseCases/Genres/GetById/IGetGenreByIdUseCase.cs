using LibraryOn.Communication.Responses.Genres;

namespace LibraryOn.Application.UseCases.Genres.GetById;
public interface IGetGenreByIdUseCase
{
    Task<ResponseGenreJson> Execute(long id);
}
