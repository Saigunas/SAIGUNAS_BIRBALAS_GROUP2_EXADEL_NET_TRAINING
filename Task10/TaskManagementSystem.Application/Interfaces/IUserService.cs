using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        System.Threading.Tasks.Task PopulateUserTable();
        Task<User> GetByIdAsync(long id);
    }
}