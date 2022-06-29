using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;
using Task5.DataAccessLayer.Persistence;

namespace Tests
{
    public class SchoolDatabaseFixture
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public SchoolDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public SchoolContext CreateContext()
        {
            return new SchoolContext(@"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True");
        }

        public void DeleteDatabase(SchoolContext context)
        {
            context.Database.EnsureDeleted();
        }

        public void SeedDatabase(SchoolContext context)
        {
            var classes = new List<Class>
            {
                new Class()
                {
                    Number = 5,
                    Letter = "C"
                }
            };
            context.Classes.AddRange(classes);

            var students = new List<Student>
            {
                new Student()
                {
                    ClassId = 1,
                    FirstName = "John",
                    LastName = "Tester",
                    PhoneNumber = 3434344,
                    Address = "fake street",
                    DateOfBirth = DateTime.Now
                }
            };
            context.Students.AddRange(students);

            context.SaveChanges();
        }
    }
}