using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Entities;

namespace LibraryOn.Application.UseCases.Genres.GetAll;
public interface IGetAllGenreUseCase
{
    Task<ResponseGenresJson> Execute();
}
