using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.RegisterAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            return StatusCode(201, result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _authService.LoginAsync(model);

            if (result == null)
                return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        // POST: api/auth/refresh-token
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(
            RefreshTokenDto request)
        {
            var result =
                await _authService.RefreshTokenAsync(
                    request.RefreshToken);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        // POST: api/auth/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(
            RefreshTokenDto request)
        {
            var result =
                await _authService.LogoutAsync(
                    request.RefreshToken);

            if (!result)
                return BadRequest();

            return Ok(new
            {
                Message = "Logout successful"
            });
        }
    }
}