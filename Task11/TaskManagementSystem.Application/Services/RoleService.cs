using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async System.Threading.Tasks.Task<Role> GetRole(int id)
        {
            var roleFound = await _roleRepository.GetAsync(id);
            return roleFound;
        }
    }
}
