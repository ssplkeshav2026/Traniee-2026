using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemApi.Services;

namespace TaskManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(new { message = $"User {id} not found" });

            return Ok(user);
        }

        [HttpPut("assign-roles/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoles( string userId, [FromBody] List<string> roles)
        {
            var result = await _userService.AssignRolesAsync(userId, roles);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}


