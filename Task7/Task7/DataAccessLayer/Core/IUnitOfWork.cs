using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Repositories;

namespace Task5.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ISubjectRepository Subjects { get; }
        int Save();
    }
}
