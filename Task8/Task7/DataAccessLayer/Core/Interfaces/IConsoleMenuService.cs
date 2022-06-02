using Task5.DataAccessLayer.Persistence;

namespace Task7.DataAccessLayer.Persistence.Services
{
    public interface IConsoleMenuService
    {
        string AskForOption(UnitOfWork unitOfWork);
    }
}