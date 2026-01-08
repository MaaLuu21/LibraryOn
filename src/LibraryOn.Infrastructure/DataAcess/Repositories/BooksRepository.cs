using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Books;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class BooksRepository : IBookWriteOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;

    public BooksRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add (Book book)
    {
        await _dbContext.AddAsync(book); 
    }

}
