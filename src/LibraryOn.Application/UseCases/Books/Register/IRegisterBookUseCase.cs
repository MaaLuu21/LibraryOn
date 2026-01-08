using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses.Book;

namespace LibraryOn.Application.UseCases.Books.Register;
public interface IRegisterBookUseCase
{
    Task<ResponseRegisteredBookJson> Execute(RequestBookJson request);
}
