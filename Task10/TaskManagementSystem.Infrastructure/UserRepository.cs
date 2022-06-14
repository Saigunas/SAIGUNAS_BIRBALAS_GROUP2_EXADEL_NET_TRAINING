using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Infrastructure
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskManagementContext context) : base(context)
        {
        }
    }
}