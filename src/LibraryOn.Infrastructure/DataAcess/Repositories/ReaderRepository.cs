using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Readers;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class ReaderRepository : IReaderWriteOnlyRepository, IReaderReadOnlyRepository, IReaderUpdateOnlyRepository
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

    async Task<Reader?> IReaderUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Readers.FirstOrDefaultAsync(r => r.Id == id);
    }

    public void Update(Reader reader)
    {
        _dbContext.Readers.Update(reader);
    }

    async Task<Reader?> IReaderReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Readers.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }
}
