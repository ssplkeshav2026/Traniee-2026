using Microsoft.AspNetCore.Mvc;
using TaskManagement.MVC.Services.Interfaces;
using TaskManagement.MVC.ViewModels.Auth;

namespace TaskManagement.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ITokenStorageService _tokenStorageService;

        public AccountController(
            IApiService apiService,
            ITokenStorageService tokenStorageService)
        {
            _apiService = apiService;
            _tokenStorageService = tokenStorageService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var response = await _apiService.PostAsync<LoginViewModel, AuthResponseViewModel>("auth/login", model);

                if (response == null)
                {
                    ModelState.AddModelError("", "Invalid login response.");
                    return View(model);
                }

                _tokenStorageService.StoreTokens(
                    response.AccessToken,
                    response.RefreshToken,
                    response.ExpiresIn);

                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var response = await _apiService.PostAsync<RegisterViewModel, AuthResponseViewModel>(
                    "auth/register",
                    model);

                if (response == null)
                {
                    ModelState.AddModelError("", "Registration failed.");
                    return View(model);
                }


                _tokenStorageService.StoreTokens(
                    response.AccessToken,
                    response.RefreshToken,
                    response.ExpiresIn);

                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                ModelState.AddModelError("", "Registration failed. Email may already exist.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = _tokenStorageService.GetRefreshToken();

            if (!string.IsNullOrEmpty(refreshToken))
            {
                try
                {
                    await _apiService.PostAsync<object, object>(
                        "auth/logout",
                        new { refreshToken });
                }
                catch
                {
                    
                }
            }

            _tokenStorageService.ClearTokens();

            return RedirectToAction("Login", "Account");
        }
    }
}