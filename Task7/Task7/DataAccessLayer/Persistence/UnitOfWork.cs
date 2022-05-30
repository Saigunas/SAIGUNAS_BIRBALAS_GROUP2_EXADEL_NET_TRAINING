using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Persistence.Repositories;
using Task5.DataAccessLayer.Repositories;

namespace Task5.DataAccessLayer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Subjects = new SubjectRepository(_context);
        }

        public ISubjectRepository Subjects { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
