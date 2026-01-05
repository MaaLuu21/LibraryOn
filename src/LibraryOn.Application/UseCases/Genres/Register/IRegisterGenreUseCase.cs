using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses.Genres;

namespace LibraryOn.Application.UseCases.Genres.Register;

public interface IRegisterGenreUseCase
{
    Task<ResponseRegisteredGenreJson> Execute(RequestGenreJson request);
}
