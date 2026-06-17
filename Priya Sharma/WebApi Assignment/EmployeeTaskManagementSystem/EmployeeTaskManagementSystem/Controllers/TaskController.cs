using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Services;

namespace TaskManagementSystemApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }

        private string? GetCurrentUserRole()
        {
            return User.FindFirstValue(ClaimTypes.Role)!;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var userId = GetCurrentUserId();
            var role = GetCurrentUserRole();

            if (userId == null)
                return Unauthorized();

            if (User.IsInRole("Employee"))
            {
                var myTasks = await _taskService.GetMyTasksAsync(userId);
                return Ok(myTasks);
            }

            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("my-tasks")]
        public async Task<IActionResult> GetMyTasks()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return Unauthorized();
            var tasks = await _taskService.GetMyTasksAsync(userId);
            return Ok(tasks);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            var assignedByUserId = GetCurrentUserId();

            await _taskService.CreateTaskAsync(dto, assignedByUserId);

            return Ok(new
            {
                Message = "Task Created Successfully"
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto dto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var userRole = GetCurrentUserRole();

                await _taskService.UpdateTaskAsync(id, dto, userId, userRole);
                return Ok(new { Message = "Task Updated Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    InnerMessage = ex.InnerException?.Message
                });
            }
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] string status)
        {
            await _taskService.UpdateTaskStatusAsync(id, status);

            return Ok(new
            {
                Message = "Status Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return Ok(new
            {
                Message = "Task Deleted Successfully"
            });
        }
    }
}
