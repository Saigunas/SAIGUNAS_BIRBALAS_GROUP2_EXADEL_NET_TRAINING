using Task5.DataAccessLayer.Persistence;
using Task7.DataAccessLayer.Persistence.Services;

namespace Task7
{
    public class GetStudentsInfoService : IGetStudentsInfoService
    {
        private readonly IConsoleMenuService _consoleMenuService;

        public GetStudentsInfoService(IConsoleMenuService consoleMenuService)
        {
            _consoleMenuService = consoleMenuService;
        }

        public async Task<string> GetInfo(UnitOfWork unitOfWork)
        {
           return await _consoleMenuService.AskForOption(unitOfWork);
        }
    }
}