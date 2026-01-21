using LibraryOn.Communication.Responses.Readers;

namespace LibraryOn.Application.UseCases.Readers.GetById;
public interface IGetReaderByIdUseCase
{
    Task<ResponseReaderJson> Execute(long id);
}
