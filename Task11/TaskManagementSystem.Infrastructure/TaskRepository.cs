using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.Infrastructure
{
    public class TaskRepository : Repository<TaskManagementSystem.Domain.Task>, ITaskRepository
    {
        public TaskRepository(TaskManagementContext context) : base(context)
        {
        }
    }
}
