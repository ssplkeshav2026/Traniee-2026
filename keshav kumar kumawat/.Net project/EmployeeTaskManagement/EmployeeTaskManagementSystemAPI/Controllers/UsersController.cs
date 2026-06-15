using EmployeeTaskManagementSystemAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementSystemAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(Roles = "Admin,Manager")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPut("{userId}/role")]
        public async Task<IActionResult> ChangeRole(string userId, string role)
        {
            var result = await _userService.ChangeUserRoleAsync(userId, role);

            if (!result)
                return BadRequest("Role change failed");

            return Ok("Role changed successfully");
        }
    }
}
