using EmployeeTaskManagementAPI.Dto;
using EmployeeTaskManagementAPI.IService;
using EmployeeTaskManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthController(IAuthService authService, IRefreshTokenService refreshTokenService)
        {
            _authService = authService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            if (result.Contains("User is already exist of this email"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found" || ex.Message == "Invalid Password")
                {
                    return Unauthorized(new
                    {
                        Message = ex.Message

                    });
                }
                return StatusCode(500, new { Message = "An internal server error occurred" });

            }

        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var result = await _refreshTokenService.RotateRefreshToken(refreshTokenDto.RefreshToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenDto dto)
        {
            var result = await _refreshTokenService.LogoutAsync(dto);

            if (result == "Invalid token")
            {
                return BadRequest(new
                {
                    Message = result
                });
            }

            return Ok(new
            {
                Message = result
            });
        }
        //[HttpGet("error")]
        //public IActionResult GetError()
        //{
        //    throw new InvalidOperationException("went wrong");
        //}
    }
}
