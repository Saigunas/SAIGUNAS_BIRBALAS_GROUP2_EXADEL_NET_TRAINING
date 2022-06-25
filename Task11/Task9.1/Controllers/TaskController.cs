using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet(Name = "GetTasks"), Authorize]
        public async Task<List<TaskManagementSystem.Domain.Task>> GetTasks()
        {
            var tasks = await _taskService.GetAllAsync();
            return tasks;
        }

        [HttpGet("{id}", Name = "GetTaskById"), Authorize]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var item = await _taskService.GetByIdAsync(id);
            return new ObjectResult(item);
        }

        [HttpPost, Authorize(Roles = "TeamLead, Senior, Middle")]
        public async Task<IActionResult> CreateTask(TaskManagementSystem.Domain.Task item)
        {
            item = await _taskService.CreateTaskAsync(item);
            return CreatedAtRoute("GetTaskById", new { id = item.Id }, item);
        }

        [HttpPut("{id}"), Authorize(Roles = "TeamLead, Senior, Middle")]
        public async Task<IActionResult> Update(long id, [FromBody] TaskManagementSystem.Domain.Task item)
        {
            await _taskService.UpdateTask(id, item);
            return new NoContentResult();
        }

        [HttpDelete("{id}"), Authorize(Roles = "TeamLead")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taskService.Remove(id);
            return new NoContentResult();
        }
    }
}