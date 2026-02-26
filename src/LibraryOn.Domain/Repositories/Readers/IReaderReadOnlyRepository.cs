using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Repositories.Readers;
public interface IReaderReadOnlyRepository
{
    Task<List<Reader>> GetAll();
    Task<Reader?> GetById(long id);
    Task<Reader?> GetByCpf(string cpf);
    Task<bool> ExistActiveReaderCpf(string cpf);
}
