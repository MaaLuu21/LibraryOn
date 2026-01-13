using LibraryOn.Application.UseCases.Genres.Delete;
using LibraryOn.Domain.Entities;

namespace LibraryOn.Application.UseCases.Books.Delete;
public interface IDeleteBookUseCase
{
    Task Execute(long id);
}
