using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Books;
public interface IBookWriteOnlyRepository
{
    Task Add(Book book);
    void Delete(Book book);
}
