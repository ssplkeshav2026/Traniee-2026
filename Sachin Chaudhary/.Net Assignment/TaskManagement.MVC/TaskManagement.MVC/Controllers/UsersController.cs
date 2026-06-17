using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Controllers
{
    [Authorize(Roles ="Admin") ]
    public class UsersController : Controller
    {
        private readonly IApiService _apiService;

        public UsersController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync("api/users");

            var users = new List<UserManagementViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                users = JsonConvert.DeserializeObject<List<UserManagementViewModel>>(content)
                        ?? new List<UserManagementViewModel>();
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Index");

            var userResponse = await _apiService.GetAsync($"api/users/{userId}");

            if (!userResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var userContent = await userResponse.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserManagementViewModel>(userContent);

            var model = new ManageUserRolesViewModel
            {
                UserId = userId,
                Email = user?.Email,
                CurrentRoles = user?.Roles ?? new List<string>(),
                AvailableRoles = new List<string>
                {
                    "Admin",
                    "Manager",
                    "Employee"
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRolesAjax([FromBody] UserRolesUpdateViewModel model)
        {
            var jsonPayload = JsonConvert.SerializeObject(model.Roles);

            var content = new StringContent(
                jsonPayload,
                Encoding.UTF8,
                "application/json");

            var response = await _apiService.PutAsync(
                $"api/users/{model.UserId}/role",
                content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    message = "Roles updated successfully!"
                });
            }

            var error = await response.Content.ReadAsStringAsync();

            return BadRequest(new
            {
                message = error
            });
        }
    }
}