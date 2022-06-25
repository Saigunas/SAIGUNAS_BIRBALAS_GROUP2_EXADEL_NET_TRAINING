using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IRoleService
    {
        System.Threading.Tasks.Task<Role> GetRole(int id);
    }
}