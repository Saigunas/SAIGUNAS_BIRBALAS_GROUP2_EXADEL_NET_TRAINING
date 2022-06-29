using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;

namespace Task7.DataAccessLayer.Core.Interfaces
{
    public interface IInfoStringFormatterService
    {
        Task<string> GetInfoString(int studentId, IUnitOfWork unitOfWork);
    }
}
