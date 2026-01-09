using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Genres;
public interface IGenresReadOnlyRepository
{
    Task<List<Genre>> GetAll();
    Task<Genre> GetById(long id);
    Task<List<Genre>> GetByIds(List<long> ids);
}
