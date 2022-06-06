using Task5.DataAccessLayer.Persistence;

namespace Task7.DataAccessLayer.Persistence.Services
{
    public interface IConsoleMenuService
    {
        Task<string> AskForOption(UnitOfWork unitOfWork);
    }
}