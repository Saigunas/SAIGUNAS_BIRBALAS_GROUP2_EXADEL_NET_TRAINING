using Task5.DataAccessLayer.Core.Domain;
using Task7.DataAccessLayer.Core.Interfaces;

namespace Task7.DataAccessLayer.Persistence.StudentServices
{
    public interface IGetLastNameService: IInfoStringFormatterService
    {
        string GetInfoString(Student student);
    }
}