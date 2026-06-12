using EmployeeTaskManagementSystemMVC.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementSystemMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UsersController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin" && role != "Manager")
                    return RedirectToAction("AccessDenied", "Auth");

                var users = await _userService.GetUsersAsync();

                return View(users);
            }
            catch
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin" && role != "Manager")
                    return RedirectToAction("AccessDenied", "Auth");

                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound();

                return View(user);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin")
                    return RedirectToAction("AccessDenied", "Auth");

                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound();

                return View(user);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string role)
        {
            try
            {
                var currentRole = _authService.GetRole();

                if (currentRole != "Admin")
                    return RedirectToAction("AccessDenied", "Auth");

                var result = await _userService.ChangeUserRoleAsync(id, role);

                if (!result)
                {
                    ModelState.AddModelError("", "Role update failed");

                    var user = await _userService.GetUserByIdAsync(id);

                    return View(user);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                var user = await _userService.GetUserByIdAsync(id);

                return View(user);
            }
        }
    }
}
