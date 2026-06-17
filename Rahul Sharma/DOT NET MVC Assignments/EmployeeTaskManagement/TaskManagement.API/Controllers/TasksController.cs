using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs.Tasks;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync(User);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id, User);
            return Ok(task);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateTask(CreateTaskRequestDto request)
        {
            var task = await _taskService.CreateTaskAsync(request, User);

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = task.Id },
                task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskRequestDto request)
        {
            var task = await _taskService.UpdateTaskAsync(id, request, User);
            return Ok(task);
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> UpdateOwnTaskStatus(int id, UpdateTaskStatusDto request)
        {
            var task = await _taskService.UpdateOwnTaskStatusAsync(id, request, User);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id, User);

            return Ok(new
            {
                message = "Task deleted successfully."
            });
        }
    }
}