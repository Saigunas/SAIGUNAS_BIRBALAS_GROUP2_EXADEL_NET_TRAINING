using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Repositories;

namespace Task5.DataAccessLayer.Persistence.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        //It is likely a bad practice to do business logic here.
        //Doing this because that is what task asked me to.
        /*
         "Put all default functions (create, read, update,
        delete) that you’ve created in task 5.3. into the repositories"
         */

        public SubjectRepository(SchoolContext context)
            : base(context)
        {
        }
        public void CreateSubject()
        {
            Console.WriteLine("Subject name: ");
            string name = Console.ReadLine();
            var subject = new Subject { Name = name };
            SchoolContext.Subjects.Add(subject);
        }

        public void UpdateSubject()
        {
            Console.WriteLine("Subject Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("New name: ");
            string name = Console.ReadLine();

            var subject = SchoolContext.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine("Err: no object found");
                return;
            }

            subject.Name = name;
        }

        public void DeleteSubject()
        {
            Console.WriteLine("Subject Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var subject = SchoolContext.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine("Err: no object found");
                return;
            }

            SchoolContext.Subjects.Remove(subject);
        }

        public void ReadSubject()
        {
            Console.WriteLine("Subject Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var subject = SchoolContext.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                Console.WriteLine("Err: no object found");
                return;
            }

            Console.WriteLine($"Subject Id: {subject.Id}");
            Console.WriteLine($"Subject name: {subject.Name}");
        }

        public SchoolContext SchoolContext
        {
            //inheriting Context from Repository<Course> and casting it
            //as PlutoContext, otherwise we would need to repeat this code
            //in every function.
            get { return Context as SchoolContext; }
        }
    }
}

