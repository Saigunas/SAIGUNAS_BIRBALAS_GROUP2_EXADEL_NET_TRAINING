using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 0,
                    Name = "TeamLead"
                },
                new Role()
                {
                    Id = 1,
                    Name = "Senior"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Middle"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Junior"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 0,
                    FullName = "Morgana Paw",
                    Email = "ss@s.com",
                    Password = "asd123",
                    RoleID = 0
                },
                new User()
                {
                    Id = 1,
                    FullName = "Joker",
                    Email = "s@sdd.com",
                    Password = "asd1asadsad23",
                    RoleID = 1
                },
                new User()
                {
                    Id = 2,
                    FullName = "Panther Rose",
                    Email = "ssggg@s.com",
                    Password = "asad1asdsad23",
                    RoleID = 2
                },
                new User()
                {
                    Id = 3,
                    FullName = "Skull",
                    Email = "sdfs@s.com",
                    Password = "asdasdasdasd123",
                    RoleID = 3
                },
                new User()
                {
                    Id = 4,
                    FullName = "Knight Zero",
                    Email = "ssss@s.com",
                    Password = "asdsdf12asd3",
                    RoleID = 3
                }
            );
        }
    }
}
