using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Genres;
public interface IGenresWriteOnlyRepository
{
    Task Add (Genre genre);
    void Delete (Genre genre);
}
