using LibraryOn.Domain.Repositories;

namespace LibraryOn.Infrastructure.DataAcess;
internal class UnityOfWork : IUnityOfWork
{
    private readonly LibraryOnDbContext _dbContext;

    public UnityOfWork(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
