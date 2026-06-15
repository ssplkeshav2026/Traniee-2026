

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Users;

namespace TaskManagement.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ITokenStorageService _tokenStorageService;

        public UsersController(
            IApiService apiService,
            ITokenStorageService tokenStorageService)
        {
            _apiService = apiService;
            _tokenStorageService = tokenStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var authCheck = AllowOnly("Admin");

            if (authCheck != null)
                return authCheck;

            var users = await _apiService.GetAsync<List<UserListViewModel>>("users");

            return View(users ?? new List<UserListViewModel>());
        }

        public async Task<IActionResult> Details(string id)
        {
            var authCheck = AllowOnly("Admin");

            if (authCheck != null)
                return authCheck;

            var user = await _apiService.GetAsync<UserDetailsViewModel>($"users/{id}");

            if (user == null)
                return RedirectToAction(nameof(Index));

            user.SelectedRole = user.Roles.FirstOrDefault() ?? "";
            user.RoleList = GetRoleList();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            var authCheck = AllowOnly("Admin");

            if (authCheck != null)
                return authCheck;

            try
            {
                var model = new UpdateUserRoleViewModel
                {
                    Role = role
                };

                await _apiService.PutAsync<UpdateUserRoleViewModel, object>(
                    $"users/{id}/role",
                    model);

                TempData["Success"] = "User role updated successfully.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (!IsInRole("Admin"))
            {
                return Json(new
                {
                    success = false,
                    message = "Access Denied. Only Admin can delete users."
                });
            }

            try
            {
                var result = await _apiService.DeleteAsync($"users/{id}");

                return Json(new
                {
                    success = result,
                    message = result
                        ? "User deleted successfully."
                        : "User delete failed."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        private IActionResult? AllowOnly(params string[] roles)
        {
            if (string.IsNullOrEmpty(_tokenStorageService.GetAccessToken()))
            {
                TempData["Error"] = "Please login first.";
                return RedirectToAction("Login", "Account");
            }

            var user = _tokenStorageService.GetLoggedInUser();

            if (user == null)
            {
                TempData["Error"] = "Please login first.";
                return RedirectToAction("Login", "Account");
            }

            if (!roles.Contains(user.Role))
            {
                TempData["Error"] =
                    $"Access Denied. Only {string.Join(" or ", roles)} can access this page.";

                return RedirectToAction("Index", "Dashboard");
            }

            return null;
        }

        private bool IsInRole(params string[] roles)
        {
            if (string.IsNullOrEmpty(_tokenStorageService.GetAccessToken()))
                return false;

            var user = _tokenStorageService.GetLoggedInUser();

            if (user == null)
                return false;

            return roles.Contains(user.Role);
        }

        private List<SelectListItem> GetRoleList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Manager", Text = "Manager" },
                new SelectListItem { Value = "Employee", Text = "Employee" }
            };
        }
    }
}