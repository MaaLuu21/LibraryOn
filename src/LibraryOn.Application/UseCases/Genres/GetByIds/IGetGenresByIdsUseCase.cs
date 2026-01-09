using LibraryOn.Communication.Responses.Genres;

namespace LibraryOn.Application.UseCases.Genres.GetByIds;
public interface IGetGenresByIdsUseCase
{
    Task<ResponseGenresJson> Execute(List<long> ids);
}
