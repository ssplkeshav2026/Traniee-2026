using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementSystemMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            return View();
        }
    }
}


