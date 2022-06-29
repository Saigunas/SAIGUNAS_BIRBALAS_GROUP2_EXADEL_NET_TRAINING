using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;

namespace Task5.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        public SchoolContext Context { get; }
        public IRepository<Class> Classes { get; set; }
        public IRepository<Student> Students { get; set; }
        public IRepository<Subject> Subjects { get; set; }
        public IRepository<ClassSubject> ClassSubjects { get; set; }
        int Save();
        void Dispose();
    }
}
