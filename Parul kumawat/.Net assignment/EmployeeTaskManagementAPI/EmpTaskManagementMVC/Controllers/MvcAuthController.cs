using Azure;
using EmpTaskManagementMVC.Filters;
using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.Services;
using EmpTaskManagementMVC.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace EmpTaskManagementMVC.Controllers
{
    public class MvcAuthController : Controller
    {
        private readonly IMvcAuthService _authService;
        private readonly IMvcUsersService _mvcUsersService;
        public MvcAuthController(IMvcAuthService authService, IMvcUsersService mvcUsersService)
        {
            _authService = authService;
            _mvcUsersService = mvcUsersService;
        }
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        [MvcValidationFilter]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(registerVM);

                }
                bool response = await _authService.RegisterAsync(registerVM);
                if (response)
                {
                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("", "Registration failed");

                return View(registerVM);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(registerVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var result = await _authService.LoginAsync(model);

                HttpContext.Session.SetString("AccessToken", result.AccessToken);

                HttpContext.Session.SetString("RefreshToken", result.RefreshToken);
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(result.AccessToken);

                var role = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

                var userName = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName ?? ""),
            new Claim(ClaimTypes.Role, role ?? "")
        };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal );

                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View("Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> LogoutRefreshToken()
        {
            try
            {
                var refreshToken = HttpContext.Session.GetString("RefreshToken");
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    await _authService.LogoutAsync(refreshToken);
                }
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return RedirectToAction("Login");
            }
        }
    }
}
