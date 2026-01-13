using LibraryOn.Communication.Responses.Book;

namespace LibraryOn.Application.UseCases.Books.GetById;
public interface IGetBookByIdUseCase
{
    Task<ResponseBookJson> Execute(long id);
}
