using Task5.DataAccessLayer.Persistence;

namespace Task7
{
    public interface IGetStudentsInfoService
    {
        Task GetInfo(UnitOfWork unitOfWork);
    }
}