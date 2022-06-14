using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskManagementContext _context;

        public TaskController(TaskManagementContext context)
        {
            _context = context;

            var application = new Application(_context);
            application.Run();
        }


        [HttpGet(Name = "GetTasks")]
        public List<TaskManagementSystem.Model.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult GetTaskById(long id)
        {
            var item = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskManagementSystem.Model.Task item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Tasks.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTaskById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TaskManagementSystem.Model.Task item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Id = item.Id;
            task.Name = item.Name;
            task.Description = item.Description;
            task.Status = item.Status;
            task.CreatorId = item.CreatorId;
            task.PerformerId = item.PerformerId;

            _context.Tasks.Update(task);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}