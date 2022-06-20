using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Infrastructure
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TaskManagementSystem.Domain.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\mssqllocaldb;Database=TaskManagementSystem;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
