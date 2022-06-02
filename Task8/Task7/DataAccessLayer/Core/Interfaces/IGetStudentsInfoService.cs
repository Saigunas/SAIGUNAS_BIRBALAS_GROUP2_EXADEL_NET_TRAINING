using Task5.DataAccessLayer.Persistence;

namespace Task7
{
    public interface IGetStudentsInfoService
    {
        void GetInfo(UnitOfWork unitOfWork);
    }
}