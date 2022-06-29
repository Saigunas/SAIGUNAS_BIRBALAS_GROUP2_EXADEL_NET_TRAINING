using Task5.DataAccessLayer;
using Task5.DataAccessLayer.Persistence;

namespace Task7
{
    public interface IGetStudentsInfoService
    {
        Task<string> GetInfo(IUnitOfWork unitOfWork);
    }
}