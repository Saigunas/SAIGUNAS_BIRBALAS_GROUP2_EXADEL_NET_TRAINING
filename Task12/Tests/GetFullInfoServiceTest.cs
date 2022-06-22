using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Persistence.StudentServices;

namespace Tests
{
    public class GetFullInfoServiceTest
    {
        private GetFullInfoService _service;

        public GetFullInfoServiceTest()
        {
            _service = new GetFullInfoService();
        }

        [Fact]
        public void GetFullInfoService_WhenCalled_ReturnsString()
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

            //Act
            var okResult = _service.GetInfoString(student);

            //Assert
            Assert.IsType<String>(okResult);
        }

        [Fact]
        public void GetFullInfoService_WhenNullPassed_ReturnsNull()
        {
            //Arrange
            Student student = null;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _service.GetInfoString(student));
        }

        [Fact]
        public void GetFullInfoService_WhenIncompleteStudentPassed_ReturnsCorrectString()
        {
            //Arrange
            var student = new Student()
            {
                Id = 1,
                Address = "fake street",
                DateOfBirth = DateTime.Now
            };

            //Act
            var okResult = _service.GetInfoString(student);

            var valueShouldReturn =
                $"Id: {student.Id}\n" +
                $"FirstName: \n" +
                $"LastName: \n" +
                $"PhoneNumber: \n" +
                $"Address: {student.Address}\n" +
                $"DateOfBirth: {student.DateOfBirth}\n";
            //Assert
            Assert.Equal(valueShouldReturn, okResult);
        }
    }
}