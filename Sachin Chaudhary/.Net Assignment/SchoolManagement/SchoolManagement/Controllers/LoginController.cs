using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;


namespace SchoolManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly SchooErpContext context;

        public LoginController(SchooErpContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Index(UserDatum user)
        {
            var newuser = context.UserData.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (newuser != null)
            {
                HttpContext.Session.SetString("UserSession", newuser.Email);
                return RedirectToAction("Index", "Home");


            }
            else
            {
                ViewBag.Message = "Login Failed..........";

            }
            return View();

        }
    }
}

