using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Communication.Responses.Readers;

namespace LibraryOn.Application.UseCases.Readers.Register;
public interface IRegisterReaderUseCase
{
    Task<ResponseRegisteredReaderJson> Execute(RequestReaderJson request);
}
