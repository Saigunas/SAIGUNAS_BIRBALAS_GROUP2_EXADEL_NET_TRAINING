using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;
using Task7.DataAccessLayer.Core.Interfaces;

namespace Task7.DataAccessLayer.Persistence.StudentServices
{
    public class GetLastNameService : IGetLastNameService
    {
        public async Task<string> GetInfoString(int studentId, IUnitOfWork unitOfWork)
        {
            Student student = await unitOfWork.Students.GetAsync(studentId);
            if (student == null)
            {
                throw new NullReferenceException();
            }

            string infoString =
                $"Id: {student.Id}\n" +
                $"LastName: {student.LastName}\n";
            return infoString;
        }
    }
}
