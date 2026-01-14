using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses.Book;

namespace LibraryOn.Application.UseCases.Books.Update;
public interface IUpdateBookUseCase
{
    Task Execute(long id, RequestBookJson request);
}
