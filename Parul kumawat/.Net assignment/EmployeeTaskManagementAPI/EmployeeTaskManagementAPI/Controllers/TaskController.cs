using EmployeeTaskManagementAPI.Dto.TasksDto;
using EmployeeTaskManagementAPI.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeTaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return BadRequest("user not found");
                }
                var result = await _taskService.CreateTaskAsync(createTaskDto, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            try
            {
                var result = await _taskService.UpdateTaskAsync(id, updateTaskDto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpGet("getAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskService.GetAllTasksAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdTask(int id)
        {
            try
            {
                var result = await _taskService.GetTaskById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _taskService.DeleteTaskAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }
        [Authorize(Roles = "Employee")]
        [HttpGet("myTasks")]
        public async Task<IActionResult> GetMyTasks()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return BadRequest("user not found");
                }
                var result = await _taskService.GetMyTasksAsync(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }


        [Authorize(Roles = "Employee")]
        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateTaskStatusDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return BadRequest("user not found");
                }

                var result = await _taskService.UpdateTaskStatusAsync(id, userId, dto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
        }

    }
}
