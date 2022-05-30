using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;

namespace Task5.DataAccessLayer.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        void CreateSubject();

        void UpdateSubject();

        void DeleteSubject();

        void ReadSubject();
    }
}
