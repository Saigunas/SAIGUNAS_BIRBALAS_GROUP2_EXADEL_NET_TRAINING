using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(long id)
        {
            var users = (await _userRepository.GetAllAsync()).ToList();
            var userById = users.FirstOrDefault(t => t.Id == id);
            return userById;
        }

        public async System.Threading.Tasks.Task PopulateUserTable()
        {
            int numberOfUsers = (await _userRepository.GetAllAsync()).Count();
            if (numberOfUsers == 0)
            {
                var user = new User();
                user.Id = 0;
                user.FullName = "Morgana Paw";
                user.Email = "ss@s.com";
                user.Password = "asd123";
                user.RoleID = 0;
                await _userRepository.AddAsync(user);

                var user1 = new User();
                user1.Id = 1;
                user1.FullName = "Joker";
                user1.Email = "s@sdd.com";
                user1.Password = "asd1asadsad23";
                user1.RoleID = 1;
                await _userRepository.AddAsync(user1);

                var user2 = new User();
                user2.Id = 2;
                user2.FullName = "Panther Rose";
                user2.Email = "ssggg@s.com";
                user2.Password = "asad1asdsad23";
                user2.RoleID = 2;
                await _userRepository.AddAsync(user2);

                var user3 = new User();
                user3.Id = 3;
                user3.FullName = "Skull";
                user3.Email = "sdfs@s.com";
                user3.Password = "asdasdasdasd123";
                user3.RoleID = 3;
                await _userRepository.AddAsync(user3);

                var user4 = new User();
                user4.Id = 4;
                user4.FullName = "Knight Zero";
                user4.Email = "ssf@s.com";
                user4.Password = "asdsdf12asd3";
                user4.RoleID = 2;
                await _userRepository.AddAsync(user4);

                _userRepository.Save();
            }
        }
    }
}

