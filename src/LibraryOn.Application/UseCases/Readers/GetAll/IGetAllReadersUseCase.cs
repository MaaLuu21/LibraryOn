using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Entities;

namespace LibraryOn.Application.UseCases.Readers.GetAll;
public interface IGetAllReadersUseCase
{
    Task<ResponseReadersJson> Execute();
}
