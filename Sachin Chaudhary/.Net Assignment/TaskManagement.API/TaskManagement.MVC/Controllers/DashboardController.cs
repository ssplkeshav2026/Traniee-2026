using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IApiService _apiService;

        public DashboardController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response;

            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
            {
                response = await _apiService.GetAsync("api/tasks");
            }
            else
            {
                response = await _apiService.GetAsync("api/tasks/mytasks");
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(content) ?? new List<TaskViewModel>();

        
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                    ?? User.FindFirst("uid")?.Value;

       
                var viewModel = new DashboardViewModel
                {
                    TotalTasks = tasks.Count,
                    CompletedTasks = tasks.Count(t => t.Status == "Completed"),
                    PendingTasks = tasks.Count(t => t.Status == "Pending" || t.Status != "Completed"),
                    MyTasksCount = tasks.Count(t => t.AssignedToUserId == currentUserId),


                    RecentTasks = tasks.AsEnumerable().Reverse().Take(5).ToList()
                };

                return View(viewModel);
            }

            var emptyViewModel = new DashboardViewModel
            {
                RecentTasks = new List<TaskViewModel>()
            };
            return View(emptyViewModel);
        }
    }
}