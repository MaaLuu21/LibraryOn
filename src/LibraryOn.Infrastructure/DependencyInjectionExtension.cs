using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Domain.Repositories.Employees;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Domain.Security.Cryptography;
using LibraryOn.Domain.Security.Tokens;
using LibraryOn.Domain.Services.LoggedEmployee;
using LibraryOn.Domain.Validators;
using LibraryOn.Infrastructure.DataAcess;
using LibraryOn.Infrastructure.DataAcess.Repositories;
using LibraryOn.Infrastructure.Security.Tokens;
using LibraryOn.Infrastructure.Services.LoggedEmployee;
using LibraryOn.Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryOn.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.Bcrypt>();
        services.AddScoped<ILoggedEmployee, LoggedEmployee>();

        AddToken(services, configuration);
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var singningKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, singningKey!));
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

        //reader
        services.AddScoped<IReaderWriteOnlyRepository, ReaderRepository>();
        services.AddScoped<IReaderReadOnlyRepository, ReaderRepository>();
        services.AddScoped<IReaderUpdateOnlyRepository, ReaderRepository>();

        //loan
        services.AddScoped<ILoanWriteOnlyRepository, LoanRepository>();

        //Employee
        services.AddScoped<IEmployeeWriteOnlyRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeReadOnlyRepository, EmployeeRepository>();



        services.AddScoped<IPhoneNumberValidator, PhoneNumberValidator>();
    }

    private static void AddDbContext (IServiceCollection services,  IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 44));

        services.AddDbContext<LibraryOnDbContext>(config => config.UseMySql(
            connectionString, serverVersion));

    }
}
