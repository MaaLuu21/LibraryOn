namespace LibraryOn.Domain.Repositories;
public interface IUnityOfWork
{
    Task Commit();
}
