using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetAllUsersAsync();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);

                if (result == null)
                {
                    return NotFound("User Not Found");
                }

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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(id);
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
        [HttpPut("edit")]
        public async Task<IActionResult> EditUser([FromBody]UpdateUserDto dto)
        {
            var result = await _userService.UpdateUserAsync(dto);
            return Ok(result);
        }
    }
}
