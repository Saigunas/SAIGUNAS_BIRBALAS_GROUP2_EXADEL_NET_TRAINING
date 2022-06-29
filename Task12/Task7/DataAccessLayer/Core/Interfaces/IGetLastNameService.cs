using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;
using Task7.DataAccessLayer.Core.Interfaces;

namespace Task7.DataAccessLayer.Persistence.StudentServices
{
    public interface IGetLastNameService: IInfoStringFormatterService
    {
        Task<string> GetInfoString(int studentId, IUnitOfWork unitOfWork);
    }
}