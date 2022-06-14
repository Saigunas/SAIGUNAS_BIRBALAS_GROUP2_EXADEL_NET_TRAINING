namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task AddTaskAsync(TaskManagementSystem.Domain.Task task);
        Task<List<TaskManagementSystem.Domain.Task>> GetAllAsync();
        Task<TaskManagementSystem.Domain.Task> GetByIdAsync(long id);
        Task<TaskManagementSystem.Domain.Task> CreateTaskAsync(TaskManagementSystem.Domain.Task item);
        Task<TaskManagementSystem.Domain.Task> UpdateTask(long id, TaskManagementSystem.Domain.Task item);
        Task Remove(long id);
    }
}