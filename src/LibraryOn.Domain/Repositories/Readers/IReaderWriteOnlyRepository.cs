using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Readers;
public interface IReaderWriteOnlyRepository
{
    Task Add(Reader reader);
    void Delete(Reader reader);
}
