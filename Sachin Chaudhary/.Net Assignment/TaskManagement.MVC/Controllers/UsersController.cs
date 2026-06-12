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
    //[Authorize(Roles = "Admin")] // Sirf Admin hi is controller ko access kar sakta hai]
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
            var response = await _apiService.GetAsync("api/admin/users");
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
            var userResponse = await _apiService.GetAsync($"api/admin/users/{userId}");
   
            var rolesResponse = await _apiService.GetAsync("api/admin/roles");

            if (userResponse.IsSuccessStatusCode && rolesResponse.IsSuccessStatusCode)
            {
                var userContent = await userResponse.Content.ReadAsStringAsync();
                var rolesContent = await rolesResponse.Content.ReadAsStringAsync();

                var userDetails = JsonConvert.DeserializeObject<UserManagementViewModel>(userContent);
                var allRoles = JsonConvert.DeserializeObject<List<string>>(rolesContent);

                var viewModel = new ManageUserRolesViewModel
                {
                    UserId = userId,
                    Email = userDetails?.Email,
                    CurrentRoles = userDetails?.Roles ?? new List<string>(),
                    AvailableRoles = allRoles ?? new List<string>()
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

    
        [HttpPost]
        public async Task<IActionResult> AssignRolesAjax([FromBody] UserRolesUpdateViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.UserId))
            {
                return BadRequest(new { message = "Invalid request payload." });
            }

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("api/admin/assign-roles", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "User roles updated successfully matrix rotated!" });
            }

            var errorMsg = await response.Content.ReadAsStringAsync();
            return BadRequest(new { message = "Failed to update roles: " + errorMsg });
        }
    }
}