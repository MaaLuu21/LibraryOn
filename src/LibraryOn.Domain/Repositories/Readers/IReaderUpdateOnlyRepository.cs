using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Readers;
public interface IReaderUpdateOnlyRepository
{
    Task<Reader?> GetById(long id);
    void Update(Reader reader);
}
