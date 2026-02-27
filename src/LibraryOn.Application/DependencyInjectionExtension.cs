using LibraryOn.Application.AutoMapper;
using LibraryOn.Application.UseCases.Books.Delete;
using LibraryOn.Application.UseCases.Books.GetAll;
using LibraryOn.Application.UseCases.Books.GetById;
using LibraryOn.Application.UseCases.Books.Register;
using LibraryOn.Application.UseCases.Books.Update;
using LibraryOn.Application.UseCases.Employee.ChangePassword;
using LibraryOn.Application.UseCases.Employee.Delete;
using LibraryOn.Application.UseCases.Employee.GetAll;
using LibraryOn.Application.UseCases.Employee.Register;
using LibraryOn.Application.UseCases.Employee.Register.Clerk;
using LibraryOn.Application.UseCases.Employee.Register.Manager;
using LibraryOn.Application.UseCases.Genres.Delete;
using LibraryOn.Application.UseCases.Genres.GetAll;
using LibraryOn.Application.UseCases.Genres.GetById;
using LibraryOn.Application.UseCases.Genres.GetByIds;
using LibraryOn.Application.UseCases.Genres.Register;
using LibraryOn.Application.UseCases.Genres.Update;
using LibraryOn.Application.UseCases.Loans.GetAll;
using LibraryOn.Application.UseCases.Loans.GetById;
using LibraryOn.Application.UseCases.Loans.GetOverdue;
using LibraryOn.Application.UseCases.Loans.Register;
using LibraryOn.Application.UseCases.Loans.RegisterReturn;
using LibraryOn.Application.UseCases.Login.DoLogin;
using LibraryOn.Application.UseCases.Readers.Delete;
using LibraryOn.Application.UseCases.Readers.GetAll;
using LibraryOn.Application.UseCases.Readers.GetByCpf;
using LibraryOn.Application.UseCases.Readers.GetById;
using LibraryOn.Application.UseCases.Readers.Register;
using LibraryOn.Application.UseCases.Readers.Update;
using LibraryOn.Domain.Repositories.Employees;
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
        services.AddScoped<IGetReaderByCpfUseCase, GetReaderByCpfUseCase>();

        //employee
        services.AddScoped<IRegisterClerkUseCase, RegisterClerkUseCase>(); 
        services.AddScoped<IRegisterManagerUseCase, RegisterManagerUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IDeleteEmployeeAccountUseCase, DeleteEmployeeAccountUseCase>();
        services.AddScoped<IGetAllEmployeesUseCase, GetAllEmployeesUseCase>();


        //Login
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

        //loan
        services.AddScoped<IRegisterLoanUseCase, RegisterLoanUseCase>();
        services.AddScoped<IUpdateLoanUseCase, UpdateLoanUseCase>();
        services.AddScoped<IGetLoanByIdUseCase, GetLoanByIdUseCase>();
        services.AddScoped<IGetLoanOverdueUseCase, GetLoanOverdueUseCase>();
        services.AddScoped<IGetAllLoanUseCase, GetAllLoanUseCase>();
    }
}
