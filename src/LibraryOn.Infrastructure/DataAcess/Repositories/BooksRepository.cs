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

    public void Delete(Book book)
    {
        _dbContext.Books.Remove(book);
    }

    public async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book?> GetById(long id)
    {
        return await _dbContext.Books
            .Include(b => b.Genres)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
