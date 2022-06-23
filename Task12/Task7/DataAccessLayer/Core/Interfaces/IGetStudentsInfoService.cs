using Task5.DataAccessLayer.Persistence;

namespace Task7
{
    public interface IGetStudentsInfoService
    {
        Task<string> GetInfo(UnitOfWork unitOfWork);
    }
}