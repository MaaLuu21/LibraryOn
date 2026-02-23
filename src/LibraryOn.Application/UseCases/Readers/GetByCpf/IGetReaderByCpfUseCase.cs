using LibraryOn.Communication.Responses.Readers;

namespace LibraryOn.Application.UseCases.Readers.GetByCpf;
public interface IGetReaderByCpfUseCase
{
    Task<ResponseReaderJson> Execute(string cpf);
}
