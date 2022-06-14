using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Model;
using TaskManagementSystem.Validators;

namespace TaskManagementSystem
{
    public class Application
    {
        private TaskManagementContext _context;

        public Application(TaskManagementContext context)
        {
            _context = context;
        }

        public void Run()
        {
            PopulateTableForTask9(_context);
        }

        public void PopulateTableForTask9(TaskManagementContext db)
        {
            if (_context.Roles.Count() == 0)
            {
                List<string> roleNames = new List<string>()
                {
                "TeamLead",
                "Senior",
                "Middle",
                "Junior"
                };

                for (int i = 0; i < roleNames.Count; i++)
                {
                    Role role = new Role();
                    role.Id = i;
                    role.Name = roleNames[i];
                    db.Roles.Add(role);
                }

                db.SaveChanges();
            }

            if (_context.Users.Count() == 0)
            {
                var user = new User();
                user.Id = 0;
                user.FullName = "Morgana Paw";
                user.Email = "ss@s.com";
                user.Password = "asd123";
                user.RoleID = 0;
                TestUserAndAdd(user);

                var user1 = new User();
                user1.Id = 1;
                user1.FullName = "Joker";
                user1.Email = "s@sdd.com";
                user1.Password = "asd1asadsad23";
                user1.RoleID = 1;
                TestUserAndAdd(user1);

                var user2 = new User();
                user2.Id = 2;
                user2.FullName = "Panther Rose";
                user2.Email = "ssggg@s.com";
                user2.Password = "asad1asdsad23";
                user2.RoleID = 2;
                TestUserAndAdd(user2);

                var user3 = new User();
                user3.Id = 3;
                user3.FullName = "Skull";
                user3.Email = "sdfs@s.com";
                user3.Password = "asdasdasdasd123";
                user3.RoleID = 3;
                TestUserAndAdd(user3);

                var user4 = new User();
                user4.Id = 4;
                user4.FullName = "Knight Zero";
                user4.Email = "ssf@s.com";
                user4.Password = "asdsdf12asd3";
                user4.RoleID = 2;
                TestUserAndAdd(user4);

                db.SaveChanges();
            }
        }

        public void TestUserAndAdd(User user)
        {
            UserValidator validator = new UserValidator();
            List<string> ValidationMessages = new List<string>();

            var validationResult = validator.Validate(user);
            if (!validationResult.IsValid)
            {
                Console.WriteLine("Some uUser was not added to database because of the following errors: ");
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                return;
            }

            _context.Users.Add(user);
        }
    }
}
