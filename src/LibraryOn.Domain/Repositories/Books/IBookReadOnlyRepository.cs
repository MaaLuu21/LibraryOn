using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Books;
public interface IBookReadOnlyRepository
{
    Task<List<Book>> GetAll();
}
