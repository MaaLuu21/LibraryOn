using LibraryOn.Communication.Responses.Book;

namespace LibraryOn.Application.UseCases.Books.GetAll
{
    public interface IGetAllBookUseCase
    {
        Task<ResponseBooksJson> Execute();
    }
}
