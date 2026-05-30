using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Data;
using RoleBasedAuth.Models;
using System.Diagnostics;

namespace RoleBasedAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Age = model.Age,
                    Status = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.Email == "admin@gmail.com" && model.Password == "Admin@123")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    return RedirectToAction("Login");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Registration model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                bool checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!checkPassword)
                {
                    ModelState.AddModelError("", "Invalid Password");
                    return View();
                }

                if (user.Status == false)
                {
                    ModelState.AddModelError("", "Your account is inactive");
                    return View();
                
                }
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password,false,false);
               

                if (result.Succeeded)
                {
                    if (model.Email == "admin@gmail.com" && model.Password == "Admin@123")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid email and password");

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
