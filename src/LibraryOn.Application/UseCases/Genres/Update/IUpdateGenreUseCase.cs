using LibraryOn.Communication.Requests.Genres;

namespace LibraryOn.Application.UseCases.Genres.Update;
public interface IUpdateGenreUseCase
{
    Task Execute(long id, RequestGenreJson request);

}
