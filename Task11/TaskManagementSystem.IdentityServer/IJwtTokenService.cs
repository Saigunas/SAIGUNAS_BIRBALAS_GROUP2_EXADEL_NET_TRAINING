using TaskManagementSystem.Domain;

namespace TaskManagementSystem.IdentityServer
{
    public interface IJwtTokenService
    {
        string CreateUserToken(User user, string role);
    }
}