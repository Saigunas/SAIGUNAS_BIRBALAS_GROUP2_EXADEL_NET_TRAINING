using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain;
using TaskManagementSystem.IdentityServer;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRoleService _roleService;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService, IRoleService roleService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _roleService = roleService;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if ((await _userRepository.GetAsync(user.Id)) != null)
            {
                throw new AppException("User already exists for this Id");
            }

            await _userRepository.AddAsync(user);
            _userRepository.Save();
            return user;
        }

        public async Task<string> Authenticate(UserDto model)
        {
            var users = await _userRepository.GetAllAsync(); 
            var user = users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            var roleName = (await _roleService.GetRole(user.RoleID)).Name;
            // authentication successful so generate jwt token
            string token = _jwtTokenService.CreateUserToken(user, roleName);

            return token;
        }

        public async Task<User> FindUser(User user)
        {
            var foundUser = await _userRepository.GetAsync(user.Id);
            return foundUser;
        }

        public async Task<User> GetByIdAsync(long id)
        {
            var users = (await _userRepository.GetAllAsync()).ToList();
            var userById = users.FirstOrDefault(t => t.Id == id);
            return userById;
        }
    }
}

