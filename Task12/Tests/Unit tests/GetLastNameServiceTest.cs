using Moq;
using Task5;
using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;
using Task7.DataAccessLayer.Persistence.StudentServices;

namespace Tests
{
    public class GetLastNameServiceTest
    {
        private GetLastNameService _service;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IRepository<Student>> _mockStudentRepo;

        public GetLastNameServiceTest()
        {
            _service = new GetLastNameService();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockStudentRepo = new Mock<IRepository<Student>>();
            _mockUnitOfWork.Setup(x => x.Students).Returns(_mockStudentRepo.Object);
        }

        [Fact]
        public void GetLastNameService_WhenCalled_ReturnsString()
        {
            //Arrange
            var student = new Student()
            {
                Id = 1,
                ClassId = 1,
                FirstName = "John",
                LastName = "Noodle",
                PhoneNumber = 222222,
                Address = "fake street",
                DateOfBirth = DateTime.Now
            };

            _mockUnitOfWork.Setup(x => x.Students.GetAsync(It.IsAny<int>())).ReturnsAsync(student);

            //Act
            var result = _service.GetInfoString(1, _mockUnitOfWork.Object);

            //Assert
            Assert.IsType<Task<String>>(result);
        }

        [Fact]
        public void GetLastNameService_WhenNonExistingIdPassed_ThrowsException()
        {
            //Arrange
            int studentId = -1;
            Student student = null;

            _mockUnitOfWork.Setup(x => x.Students.GetAsync(It.IsAny<int>())).ReturnsAsync(student);
            //Act
            //Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _service.GetInfoString(studentId, _mockUnitOfWork.Object));
        }

        [Fact]
        public async Task GetLastNameService_WhenIncompleteStudentPassed_ReturnsCorrectString()
        {
            //Arrange
            var student = new Student()
            {
                Id = 1,
            };

            var expected =
                $"Id: {student.Id}\n" +
                $"LastName: \n";

            _mockUnitOfWork.Setup(x => x.Students.GetAsync(It.IsAny<int>())).ReturnsAsync(student);

            //Act
            var result = await _service.GetInfoString(student.Id, _mockUnitOfWork.Object);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}