using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Readers;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class ReaderRepository : IReaderWriteOnlyRepository
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
}
