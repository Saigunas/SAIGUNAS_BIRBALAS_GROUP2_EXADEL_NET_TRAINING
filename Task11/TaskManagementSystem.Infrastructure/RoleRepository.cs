using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Infrastructure
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(TaskManagementContext context) : base(context)
        {
        }
    }
}