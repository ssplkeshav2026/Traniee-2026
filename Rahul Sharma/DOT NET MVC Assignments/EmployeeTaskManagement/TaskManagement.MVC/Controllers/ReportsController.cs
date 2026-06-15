


using Microsoft.AspNetCore.Mvc;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Dashboard;

namespace TaskManagement.MVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ITokenStorageService _tokenStorageService;

        public ReportsController(
            IApiService apiService,
            ITokenStorageService tokenStorageService)
        {
            _apiService = apiService;
            _tokenStorageService = tokenStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var authCheck = AllowOnly("Admin", "Manager");

            if (authCheck != null)
                return authCheck;

            var stats = await _apiService.GetAsync<DashboardViewModel>("dashboard/stats");

            return View(stats ?? new DashboardViewModel());
        }

        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(_tokenStorageService.GetAccessToken());
        }

        private string GetCurrentRole()
        {
            var user = _tokenStorageService.GetLoggedInUser();
            return user?.Role ?? "";
        }

        private IActionResult? AllowOnly(params string[] roles)
        {
            if (!IsLoggedIn())
            {
                TempData["Error"] = "Please login first.";
                return RedirectToAction("Login", "Account");
            }

            var role = GetCurrentRole();

            if (!roles.Contains(role))
            {
                TempData["Error"] = "You are not authorized to access reports.";
                return RedirectToAction("Index", "Dashboard");
            }

            return null;
        }
    }
}