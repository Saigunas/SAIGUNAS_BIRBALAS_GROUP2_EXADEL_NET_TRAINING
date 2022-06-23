﻿using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Persistence.StudentServices;

namespace Tests
{
    public class GetLastNameServiceTest
    {
        private GetLastNameService _service;

        public GetLastNameServiceTest()
        {
            _service = new GetLastNameService();
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

            //Act
            var result = _service.GetInfoString(student);

            //Assert
            Assert.IsType<String>(result);
        }

        [Fact]
        public void GetLastNameService_WhenNullPassed_ThrowsException()
        {
            //Arrange
            Student student = null;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _service.GetInfoString(student));
        }

        [Fact]
        public void GetLastNameService_WhenIncompleteStudentPassed_ReturnsCorrectString()
        {
            //Arrange
            var student = new Student()
            {
                Id = 1,
            };

            //Act
            var result = _service.GetInfoString(student);

            var expected =
                $"Id: {student.Id}\n" +
                $"LastName: \n";
            //Assert
            Assert.Equal(expected, result);
        }
    }
}