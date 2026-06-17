using Microsoft.AspNetCore.Mvc;

namespace First.netAssigmnet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


