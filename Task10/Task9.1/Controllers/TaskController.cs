using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Task9._1;
using TaskManagementSystem.Application.Interfaces;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet(Name = "GetTasks")]
        public async Task<List<TaskManagementSystem.Domain.Task>> GetTasks()
        {
            var tasks = await _taskService.GetAllAsync();
            return tasks;
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var item = await _taskService.GetByIdAsync(id);
            return new ObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskManagementSystem.Domain.Task item)
        {
            item = await _taskService.CreateTaskAsync(item);
            return CreatedAtRoute("GetTaskById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] TaskManagementSystem.Domain.Task item)
        {
            await _taskService.UpdateTask(id, item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taskService.Remove(id);
            return new NoContentResult();
        }
    }
}