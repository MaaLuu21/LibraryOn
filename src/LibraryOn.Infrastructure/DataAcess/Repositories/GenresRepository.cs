using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Genres;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class GenresRepository : IGenresReadOnlyRepository, IGenresWriteOnlyRepository, IGenresUpdateOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;

    public GenresRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Genre genre)
    {
        await _dbContext.Genres.AddAsync(genre);
    }

    public void Delete(Genre genre)
    {
        _dbContext.Genres.Remove(genre);
    }

    public async Task<List<Genre>> GetAll()
    {
        return await _dbContext.Genres.AsNoTracking().ToListAsync();
    }

    async Task<Genre?> IGenresReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
    }

    async Task<Genre?> IGenresUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
    }
    public async Task<List<Genre>> GetByIds(List<long> ids)
    {
        return await _dbContext.Genres
            .Where(g => ids.Contains(g.Id))
            .ToListAsync();
    }

    public void Update(Genre genre)
    {
        _dbContext.Genres.Update(genre);
    }
}
