using LibraryOn.Communication.Requests.Readers;

namespace LibraryOn.Application.UseCases.Readers.Update;
public interface IUpdateReaderUseCase
{
    Task Execute(long id, RequestReaderJson request);
}
