


using Microsoft.AspNetCore.Mvc;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Dashboard;

namespace TaskManagement.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITokenStorageService _tokenStorageService;
        private readonly IApiService _apiService;

        public DashboardController(
            ITokenStorageService tokenStorageService,
            IApiService apiService)
        {
            _tokenStorageService = tokenStorageService;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(_tokenStorageService.GetAccessToken()))
                return RedirectToAction("Login", "Account");

            var user = _tokenStorageService.GetLoggedInUser();

            if (user == null)
                return RedirectToAction("Login", "Account");

            var stats = await _apiService.GetAsync<DashboardViewModel>("dashboard/stats");

            var model = new DashboardViewModel
            {
                User = user,
                TotalTasks = stats?.TotalTasks ?? 0,
                PendingTasks = stats?.PendingTasks ?? 0,
                InProgressTasks = stats?.InProgressTasks ?? 0,
                CompletedTasks = stats?.CompletedTasks ?? 0,
                RecentTasks = stats?.RecentTasks ?? new List<RecentTaskViewModel>(),

            };

            return View(model);
        }
    }
}