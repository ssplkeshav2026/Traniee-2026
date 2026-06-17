using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IApiService _apiService;

        public TasksController(IApiService apiService)
        {
            _apiService = apiService;
        }

      
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync("api/tasks");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(content);
                return View(tasks ?? new List<TaskViewModel>());
            }

            TempData["ErrorMessage"] = "Unable to retrieve tasks.";
            return View(new List<TaskViewModel>());
        }

       
        [HttpGet]
        public async Task<IActionResult> MyTasks()
        {
            var response = await _apiService.GetAsync("api/tasks");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var allTasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(content) ?? new List<TaskViewModel>();

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                             ?? User.FindFirst("uid")?.Value;

                var myTasks = allTasks.Where(t => t.AssignedToUserId == userId).ToList();
                return View(myTasks);
            }

            TempData["ErrorMessage"] = "Unable to retrieve your tasks.";
            return View(new List<TaskViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiService.GetAsync($"api/tasks/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<TaskViewModel>(content);
                return View(task);
            }

            TempData["ErrorMessage"] = "Task details not found.";
            return RedirectToAction("Index");
        }

  
        [HttpGet]
        public IActionResult Create() => View();

   
        [HttpPost]
        public async Task<IActionResult> CreateAjax([FromBody] TaskViewModel model)
        {
            
            if (model == null)
                return BadRequest(new { message = "Payload structure is completely null." });


            if (string.IsNullOrEmpty(model.Status)) model.Status = "Pending";
            if (string.IsNullOrEmpty(model.Description)) model.Description = "";

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("api/tasks", content);

            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Task created successfully!" });

     
            var apiError = await response.Content.ReadAsStringAsync();
            return BadRequest(new { message = "Backend API rejection: " + apiError });
        }
       
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiService.GetAsync($"api/tasks/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<EditTaskViewModel>(content);
                return View(task);
            }

            TempData["ErrorMessage"] = "Task not found.";
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public async Task<IActionResult> UpdateAjax(int id, [FromBody] EditTaskViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(new { message = "Validation failed." });

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"api/tasks/{id}", content);

            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Task Updated Successfully!" });

            return BadRequest(new { message = "Failed to update task." });
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            
            var response = await _apiService.DeleteAsync($"api/tasks/{id}");

            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Task Deleted Successfully." });

            return BadRequest(new { message = "Failed to delete task." });
        }
    }
}