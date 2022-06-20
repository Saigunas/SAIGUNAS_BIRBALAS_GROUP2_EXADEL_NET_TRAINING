using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<string> Authenticate(UserDto model);
        Task<User> FindUser(User user);
        Task<User> GetByIdAsync(long id);
    }
}