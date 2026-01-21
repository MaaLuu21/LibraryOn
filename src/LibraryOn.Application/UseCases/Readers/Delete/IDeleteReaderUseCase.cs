namespace LibraryOn.Application.UseCases.Readers.Delete;
public interface IDeleteReaderUseCase
{
    Task Execute(long id);
}
