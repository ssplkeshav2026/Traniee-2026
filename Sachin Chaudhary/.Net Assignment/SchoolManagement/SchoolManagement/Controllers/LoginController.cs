using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Models;
using System.Linq;

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
            // In a real application, ensure the password is encrypted/hashed before checking!
            var newuser = context.UserData.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (newuser != null)
            {
                HttpContext.Session.SetString("UserSession", newuser.Email);
                return RedirectToAction("Dash1");
            }
            else
            {
                ViewBag.Message = "Login Failed..........";
                return View(user); // Returns the login view and preserves entered data
            }
        }

        public IActionResult Dash1()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
