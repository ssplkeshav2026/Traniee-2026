using EmployeeTaskManagementSystemMVC.Filters;
using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementSystemMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await _authService.LoginAsync(model);

                if (result == null)
                {
                    ModelState.AddModelError("", "Invalid email or password");
                    return View(model);
                }

                _authService.SaveTokens(result);

                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(model);
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            try
            {
                var result = await _authService.RegisterAsync(model);

                if (!result)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View(model);
                }
 
                var loginResult = await _authService.LoginAsync(new LoginVM
                {
                    Email = model.Email,
                    Password = model.Password
                });

                if (loginResult == null)
                {
                    ModelState.AddModelError("", "Auto login failed");
                    return View(model);
                }

                _authService.SaveTokens(loginResult);

                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogoutAsync();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Index", "Dashboard");
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
