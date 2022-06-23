using Task5.DataAccessLayer.Persistence;
using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Core.Interfaces;
using Task7.DataAccessLayer.Persistence.StudentServices;

namespace Task7.DataAccessLayer.Persistence.Services
{
    public class ConsoleMenuService : IConsoleMenuService
    {
        private IGetFullInfoService _getFullInfoService;
        private IGetLastNameService _getLastNameService;

        public ConsoleMenuService(IGetFullInfoService getFullInfoService, IGetLastNameService getLastNameService)
        {
            _getFullInfoService = getFullInfoService;
            _getLastNameService = getLastNameService;
        }
        public async Task<string> AskForOption(UnitOfWork unitOfWork)
        {
            IInfoStringFormatterService studentInfo = null;
            Student student = null;

            bool showMenu = true;
            while (showMenu)
            {
                int selection = AskForService();

                switch (selection)
                {
                    case 1:
                        {
                            showMenu = false;
                            studentInfo = _getFullInfoService;
                            break;
                        }
                    case 2:
                        {
                            showMenu = false;
                            studentInfo = _getLastNameService;
                            break;
                        }
                    case 3:
                        showMenu = false;
                        return "";
                    default:
                        Console.WriteLine("Wrong choice");
                        continue;
                }

                int studentId = AskForId();
                Console.WriteLine();

                student = await unitOfWork.Students.GetAsync(studentId);
                if (student == null)
                {
                    throw new NullReferenceException();
                }
            }
            return studentInfo.GetInfoString(student);
        }

        public virtual int AskForService()
        {
            Console.WriteLine("Select the option: ");
            Console.WriteLine("1. Get student info");
            Console.WriteLine("2. Get student last name");
            Console.WriteLine("3. Exit");

            int selection = Convert.ToInt32(Console.ReadLine());
            return selection;
        }

        public virtual int AskForId()
        {

            Console.Write("Enter The Id: ");

            int studentId = Convert.ToInt32(Console.ReadLine());
            return studentId;
        }

    }
}