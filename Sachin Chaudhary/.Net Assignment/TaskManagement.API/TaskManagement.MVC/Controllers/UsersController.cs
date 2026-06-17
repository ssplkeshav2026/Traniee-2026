using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Controllers
{
    [Authorize] 
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
                users = JsonConvert.DeserializeObject<List<UserManagementViewModel>>(content) ?? new List<UserManagementViewModel>();
            }

            return View(users);
        }


     
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var userResponse = await _apiService.GetAsync($"api/users/{userId}");

            if (!userResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var userContent = await userResponse.Content.ReadAsStringAsync();

            var userDetails =
                JsonConvert.DeserializeObject<UserManagementViewModel>(userContent);

            var viewModel = new ManageUserRolesViewModel
            {
                UserId = userId,
              
                CurrentRoles = userDetails?.Roles ?? new List<string>(),

                AvailableRoles = new List<string>
        {
            "Admin",
            "Manager",
            "Employee"
        }
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRolesAjax([FromBody] UserRolesUpdateViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.UserId))
            {
                return BadRequest(new { message = "Invalid request payload." });
            }

            var json = JsonConvert.SerializeObject(model.Roles);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _apiService.PutAsync(
                $"api/users/{model.UserId}/role",
                content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new
                {
                    message = "Roles updated successfully."
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