using Microsoft.AspNetCore.Mvc;

namespace First.netAssigmnet.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}