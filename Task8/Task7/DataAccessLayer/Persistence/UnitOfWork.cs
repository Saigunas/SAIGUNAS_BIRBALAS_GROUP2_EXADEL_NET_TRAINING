using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence.Repositories;

namespace Task5.DataAccessLayer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;
        public IRepository<Class> Classes;
        public IRepository<Student> Students;
        public IRepository<Subject> Subjects;
        public IRepository<ClassSubject> ClassSubjects;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Subjects = new Repository<Subject>(_context);
            Classes = new Repository<Class>(_context);
            Students = new Repository<Student>(_context);
            ClassSubjects = new Repository<ClassSubject>(_context);
        }

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
