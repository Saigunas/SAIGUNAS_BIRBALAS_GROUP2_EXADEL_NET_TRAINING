using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserService _userService;

        public TaskService(ITaskRepository taskRepository, IUserService userService)
        {
            _taskRepository = taskRepository;
            _userService = userService;
        }
        public async Task AddTaskAsync(TaskManagementSystem.Domain.Task task)
        {
            await _taskRepository.AddAsync(task);
            _taskRepository.Save();
        }

        public async Task<List<TaskManagementSystem.Domain.Task>> GetAllAsync()
        {
            var tasks = (await _taskRepository.GetAllAsync()).ToList();
            return tasks;
        }

        public async Task<TaskManagementSystem.Domain.Task> GetByIdAsync(long id)
        {
            var tasks = (await _taskRepository.GetAllAsync()).ToList();
            var taskById = tasks.FirstOrDefault(t => t.Id == id);
            if (taskById == null)
            {
                throw new KeyNotFoundException();
            }
            return taskById;
        }

        public async Task<TaskManagementSystem.Domain.Task> CreateTaskAsync(TaskManagementSystem.Domain.Task item)
        {
            if (item == null)
            {
                throw new AppException("Task provided can not be null");
            }

            if (item.Description != "")
            {
                item.Description += " ";
            }

            string creatorFullName = (await _userService.GetByIdAsync(item.CreatorId)).FullName;

            if (item.PerformerId != null)
            {
                string performerFullName = (await _userService.GetByIdAsync((long)(int)item.PerformerId)).FullName;
                item.Description += $"Creator: {creatorFullName}. Created: {DateTime.Now.ToString()}. Performer: {performerFullName}";
            }
            else
            {
                item.Description += $"Creator: {creatorFullName}. Created: {DateTime.Now.ToString()}. No performer";
            }

            await _taskRepository.AddAsync(item);
            _taskRepository.Save();

            return item;
        }

        public async Task<TaskManagementSystem.Domain.Task> UpdateTask(long id, TaskManagementSystem.Domain.Task item)
        {
            if (item == null)
            {
                throw new AppException("Must provide an updated task body.");
            }
            if (item.Id != id)
            {
                throw new AppException("Updated entity must have the same id");
            }

            var task = await _taskRepository.GetAsync((int)id);
            if (task == null)
            {
                throw new KeyNotFoundException();
            }

            task.Id = item.Id;
            task.Name = item.Name;
            task.Description = item.Description;
            task.Status = item.Status;
            task.CreatorId = item.CreatorId;
            task.PerformerId = item.PerformerId;

            _taskRepository.Save();

            return task;
        }

        public async Task Remove(long id)
        {
            var task = await _taskRepository.GetAsync((int)id);
            if (task == null)
            {
                throw new KeyNotFoundException();
            }

            _taskRepository.Remove(task);
            _taskRepository.Save();
        }
    }
}
