using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskManagementSystemMVC.Helper;
using TaskManagementSystemMVC.Services;
using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in go to home
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var (success, accessToken, refreshToken, error) =
                await _authService.LoginAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            TokenHelper.SetTokens(Response, accessToken, refreshToken,model.RememberMe  );

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(accessToken);

            var claims = jwt.Claims.ToList();

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = model.RememberMe
                                 ? DateTimeOffset.UtcNow.AddDays(7)
                                 : DateTimeOffset.UtcNow.AddMinutes(30)
                });
            return RedirectToAction("Index", "Home");
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

            var (success, error) = await _authService.RegisterAsync(model);

            if (!success)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            TokenHelper.ClearTokens(Response);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
