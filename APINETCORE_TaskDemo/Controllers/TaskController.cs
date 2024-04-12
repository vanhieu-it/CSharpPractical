using APINETCORE_TaskDemo.Models.RequestModels;
using APINETCORE_TaskDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace APINETCORE_TaskDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            var task = _taskService.GetOne(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetOne), new { id = task.TaskId }, task);
        }
    }
}