using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class BooksRepository : IBookWriteOnlyRepository, IBookReadOnlyRepository
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

    public async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();
    }
}
