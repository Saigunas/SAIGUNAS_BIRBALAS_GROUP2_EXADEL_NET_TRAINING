using Moq;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;
using Task7;
using Task7.DataAccessLayer.Persistence.Services;
using Task7.DataAccessLayer.Persistence.StudentServices;

namespace Tests
{
    public class GetStudentsInfoServiceIntegrationTest : IClassFixture<SchoolDatabaseFixture>
    {
        private GetFullInfoService _getFullInfoService;
        private GetLastNameService _getLastNameService;
        private Mock<ConsoleMenuService> _mockConsoleMenuService;
        private GetStudentsInfoService _getStudentsInfoService;
        
        public SchoolDatabaseFixture Fixture { get; }

        public GetStudentsInfoServiceIntegrationTest(SchoolDatabaseFixture fixture)
        {
            _getFullInfoService = new GetFullInfoService();
            _getLastNameService = new GetLastNameService();
            _mockConsoleMenuService = new Mock<ConsoleMenuService>(_getFullInfoService, _getLastNameService);
            _getStudentsInfoService = new GetStudentsInfoService(_mockConsoleMenuService.Object);
            Fixture = fixture;
        }


        [Fact]
        public async Task GetStudentsInfoService_TakesStudentFromDatabase_ReturnsFullInfo()
        {
            //Arrange

            //Console input is mocked
            _mockConsoleMenuService.Setup(x => x.AskForService()).Returns(1);
            _mockConsoleMenuService.Setup(x => x.AskForId()).Returns(1);
            
            //Act
            string result;
            string expected;
            using (var context = Fixture.CreateContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    /* Before seeding database, begins transaction to track changes
                     * At the end clears any changes */
                    context.Database.BeginTransaction();
                    Fixture.SeedDatabase(context);

                    result = await _getStudentsInfoService.GetInfo(unitOfWork);
                    
                    Student student = await unitOfWork.Students.GetAsync(1);
                    expected =
                        $"Id: {student.Id}\n" +
                        $"FirstName: {student.FirstName}\n" +
                        $"LastName: {student.LastName}\n" +
                        $"PhoneNumber: {student.PhoneNumber}\n" +
                        $"Address: {student.Address}\n" +
                        $"DateOfBirth: {student.DateOfBirth}\n";

                    context.ChangeTracker.Clear();
                }
            }

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetStudentsInfoService_TakesNullFromDatabase_ThrowsException()
        {
            //Arrange

            //Console input is mocked
            _mockConsoleMenuService.Setup(x => x.AskForService()).Returns(1);
            _mockConsoleMenuService.Setup(x => x.AskForId()).Returns(999);

            //Act
            string result;
            using (var context = Fixture.CreateContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    //Assert
                    await Assert.ThrowsAsync<NullReferenceException>(async () => await _getStudentsInfoService.GetInfo(unitOfWork));
                }
            }
        }
    }
}
