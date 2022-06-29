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
        public SchoolContext Context { get; private set; }
        public IRepository<Class> Classes { get; set; }
        public IRepository<Student> Students { get; set; }
        public IRepository<Subject> Subjects { get; set; }
        public IRepository<ClassSubject> ClassSubjects { get; set; }

        public UnitOfWork(SchoolContext context)
        {
            Context = context;
            Subjects = new Repository<Subject>(Context);
            Classes = new Repository<Class>(Context);
            Students = new Repository<Student>(Context);
            ClassSubjects = new Repository<ClassSubject>(Context);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
