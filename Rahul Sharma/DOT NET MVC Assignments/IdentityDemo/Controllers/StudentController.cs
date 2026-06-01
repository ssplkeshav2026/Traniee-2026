using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Controllers
{
    public class StudentController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
