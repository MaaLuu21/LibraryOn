using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Readers;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class ReaderRepository : IReaderWriteOnlyRepository, IReaderReadOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;

    public ReaderRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Reader reader)
    {
        await _dbContext.Readers.AddAsync(reader);
    }

    public void Delete(Reader reader)
    {
        _dbContext.Readers.Remove(reader);
    }

    public Task<List<Reader>> GetAll()
    {
        return _dbContext.Readers.AsNoTracking().ToListAsync();
    }

    public async Task<Reader?> GetById(long id)
    {
        return await _dbContext.Readers.FirstOrDefaultAsync(r => r.Id == id);
    }
}
