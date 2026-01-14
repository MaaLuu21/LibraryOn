using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Infrastructure.DataAcess;
using LibraryOn.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryOn.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
    {
       AddDbContext(services, configuration);
       AddRepositories(services);
    }

    private static void AddRepositories (IServiceCollection services)
    {
        //genre
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IGenresWriteOnlyRepository, GenresRepository>();
        services.AddScoped<IGenresReadOnlyRepository, GenresRepository>();
        services.AddScoped<IGenresUpdateOnlyRepository, GenresRepository>();
        //book
        services.AddScoped<IBookWriteOnlyRepository, BooksRepository>();
        services.AddScoped<IBookReadOnlyRepository, BooksRepository>();
        services.AddScoped<IBookUpdateOnlyRepository, BooksRepository>();
    }

    private static void AddDbContext (IServiceCollection services,  IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 44));

        services.AddDbContext<LibraryOnDbContext>(config => config.UseMySql(
            connectionString, serverVersion));

    }
}
