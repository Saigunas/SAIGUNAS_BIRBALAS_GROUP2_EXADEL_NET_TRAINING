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

        public async System.Threading.Tasks.Task PopulateRoleTable()
        {
            int numberOfRoles = (await _roleRepository.GetAllAsync()).Count();
            if (numberOfRoles == 0)
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
                    await _roleRepository.AddAsync(role);
                }

                _roleRepository.Save();
            }
        }
    }
}
