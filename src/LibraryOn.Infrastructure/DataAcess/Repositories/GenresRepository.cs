using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Genres;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class GenresRepository : IGenresReadOnlyRepository, IGenresWriteOnlyRepository
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
        //implementar
        throw new NotImplementedException();
    }

    public Task<List<Genre>> GetAll()
    {
        //implementar
        throw new NotImplementedException();
    }
}
