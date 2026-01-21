using LibraryOn.Application.AutoMapper;
using LibraryOn.Application.UseCases.Books.Delete;
using LibraryOn.Application.UseCases.Books.GetAll;
using LibraryOn.Application.UseCases.Books.GetById;
using LibraryOn.Application.UseCases.Books.Register;
using LibraryOn.Application.UseCases.Books.Update;
using LibraryOn.Application.UseCases.Genres.Delete;
using LibraryOn.Application.UseCases.Genres.GetAll;
using LibraryOn.Application.UseCases.Genres.GetById;
using LibraryOn.Application.UseCases.Genres.GetByIds;
using LibraryOn.Application.UseCases.Genres.Register;
using LibraryOn.Application.UseCases.Genres.Update;
using LibraryOn.Application.UseCases.Readers.Delete;
using LibraryOn.Application.UseCases.Readers.GetAll;
using LibraryOn.Application.UseCases.Readers.GetById;
using LibraryOn.Application.UseCases.Readers.Register;
using LibraryOn.Application.UseCases.Readers.Update;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryOn.Application;
public static class DependencyInjectionExtension
{
    //adicionar injeção de dependencia
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);

    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {

        //genre
        services.AddScoped<IRegisterGenreUseCase, RegisterGenreUseCase>();
        services.AddScoped<IGetGenreByIdUseCase, GetGenreByIdUseCase>();
        services.AddScoped<IDeleteGenreUseCase, DeleteGenreUseCase>();
        services.AddScoped<IUpdateGenreUseCase, UpdateGenreUseCase>();
        services.AddScoped<IGetAllGenreUseCase, GetAllGenreUseCase>();
        services.AddScoped<IGetGenresByIdsUseCase, GetGenresByIdsUseCase>();
        
        //book
        services.AddScoped<IRegisterBookUseCase, RegisterBookUseCase>();
        services.AddScoped<IGetAllBookUseCase, GetAllBookUseCase>();
        services.AddScoped<IGetBookByIdUseCase, GetBookByIdUseCase>();
        services.AddScoped<IDeleteBookUseCase, DeleteBookUseCase>();
        services.AddScoped<IUpdateBookUseCase, UpdateBookUseCase>();

        //reader
        services.AddScoped<IRegisterReaderUseCase, RegisterReaderUseCase>();
        services.AddScoped<IGetAllReadersUseCase, GetAllReadersUseCase>();
        services.AddScoped<IGetReaderByIdUseCase, GetReaderByIdUseCase>();
        services.AddScoped<IDeleteReaderUseCase, DeleteReaderUseCase>();
        services.AddScoped<IUpdateReaderUseCase, UpdateReaderUseCase>();
        


    }
}
