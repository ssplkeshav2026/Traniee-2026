using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemMVC.Services;

namespace TaskManagementSystemMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoles(string userId, List<string> selectedRoles)
        {
            await _userService.UpdateRolesAsync(userId, selectedRoles);

            return RedirectToAction(nameof(Index));
        }
    }
}
