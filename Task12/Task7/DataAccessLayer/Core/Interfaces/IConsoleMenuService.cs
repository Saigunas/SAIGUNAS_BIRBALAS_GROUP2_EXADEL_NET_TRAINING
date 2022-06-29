using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Persistence;

namespace Task7.DataAccessLayer.Persistence.Services
{
    public interface IConsoleMenuService
    {
        Task<string> AskForOption(IUnitOfWork unitOfWork);
        int AskForId();
        int AskForService();
    }
}