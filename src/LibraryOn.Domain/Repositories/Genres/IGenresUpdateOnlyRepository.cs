using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Genres;
public interface IGenresUpdateOnlyRepository
{
    Task<Genre?> GetById(long id);
    void Update(Genre genre);
}
