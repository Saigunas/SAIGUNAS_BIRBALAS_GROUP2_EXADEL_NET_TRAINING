using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;
using Task7.DataAccessLayer.Persistence.Services;

namespace Task7
{
    public class Application : IApplication
    {
        private readonly IGetStudentsInfoService _getStudentsInfoService;

        public Application(IGetStudentsInfoService getStudentsInfoService)
        {
            _getStudentsInfoService = getStudentsInfoService;
        }

        public async Task Run()
        {
            using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            {
                PopulateTableForTask7_2(unitOfWork);
                await _getStudentsInfoService.GetInfo(unitOfWork);
            }
        }

        public void PopulateTableForTask7_2(UnitOfWork unitOfWork)
        {
            var newClass = new Class();
            newClass.Number = 5;
            newClass.Letter = "b";

            unitOfWork.Classes.AddAsync(newClass);

            var newStudent = new Student();
            newStudent.FirstName = "Morgana";
            newStudent.LastName = "Paw";
            newStudent.Address = "Metaverse";
            newStudent.PhoneNumber = 3664545;
            newStudent.DateOfBirth = new DateTime(1987, 7, 15, 10, 39, 30);
            newStudent.ClassId = 1;

            unitOfWork.Students.AddAsync(newStudent);

            unitOfWork.Save();
        }
    }
}
