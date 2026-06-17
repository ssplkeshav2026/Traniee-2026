using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.API.DTOs;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(
            ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]

        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetAll()
        {
            var tasks =
                await _taskService.GetAllAsync();

            return Ok(tasks);
        }
        [HttpGet("mytasks")]
        [Authorize]
        public async Task<IActionResult> GetMyTasks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var tasks = await _taskService.GetAllAsync();

            var myTasks = tasks
                .Where(t => t.AssignedToUserId == userId)
                .ToList();

            return Ok(myTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task =
                await _taskService.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create(
            CreateTaskDto dto)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            var task =
                await _taskService.CreateAsync(
                    dto,
                    userId);

            return CreatedAtAction(
                nameof(Get),
                new { id = task.Id },
                task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTaskDto dto)
        {
            var result =
                await _taskService.UpdateAsync(
                    id,
                    dto);

            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var result =
                await _taskService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}