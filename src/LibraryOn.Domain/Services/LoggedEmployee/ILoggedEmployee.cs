using LibraryOn.Domain.Entities;

namespace LibraryOn.Domain.Services.LoggedEmployee
{
    public interface ILoggedEmployee
    {
        Task<Employee> Get();
    }
}
