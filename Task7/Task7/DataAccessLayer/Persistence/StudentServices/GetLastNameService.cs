using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Core.Interfaces;

namespace Task7.DataAccessLayer.Persistence.StudentServices
{
    internal class GetLastNameService : IInfoStringFormatterService
    {
        public string GetInfoString(Student student)
        {
            string infoString =
                $"Id: {student.Id}\n" +
                $"LastName: {student.LastName}\n";
            return infoString;
        }
    }
}
