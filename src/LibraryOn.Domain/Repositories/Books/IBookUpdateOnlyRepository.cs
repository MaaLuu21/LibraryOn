using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Books;
public interface IBookUpdateOnlyRepository
{
    Task<Book?> GetById(long id);
    void Update(Book book);
}
