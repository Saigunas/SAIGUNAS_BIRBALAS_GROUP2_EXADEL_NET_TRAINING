using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Core.Interfaces;

namespace Task7.DataAccessLayer.Persistence.StudentServices
{
    public class GetFullInfoService : IGetFullInfoService
    {
        public string GetInfoString(Student student)
        {
            string infoString =
                $"Id: {student.Id}\n" +
                $"FirstName: {student.FirstName}\n" +
                $"LastName: {student.LastName}\n" +
                $"PhoneNumber: {student.PhoneNumber}\n" +
                $"Address: {student.Address}\n" +
                $"DateOfBirth: {student.DateOfBirth}\n";
            return infoString;
        }
    }
}
