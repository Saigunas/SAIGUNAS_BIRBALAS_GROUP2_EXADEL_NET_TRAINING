using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Models;

namespace Task6
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appconfig.json", optional: false).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("myDbConn"));
        }
    }
}
