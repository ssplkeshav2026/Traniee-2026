using EmpTaskManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmpTaskManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
