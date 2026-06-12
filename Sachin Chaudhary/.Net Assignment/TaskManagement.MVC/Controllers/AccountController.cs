using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AccountController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            // If the user is already authenticated, redirect them directly to the Dashboard
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Login(model);

            if (result == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(model);
            }

            // Securely store tokens inside HttpOnly Cookies via TokenService
            await _tokenService.SetTokens(result.AccessToken, result.RefreshToken);

            // Prepare claims identity list for cookie authentication setup
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, result.Email ?? model.Email),
                new Claim(ClaimTypes.Email, result.Email ?? model.Email),
                new Claim(ClaimTypes.Role, result.Role ?? "Employee")
            };

            // Explicitly pass ClaimTypes.Name and ClaimTypes.Role to the constructor 
            // so that user context middleware reads authorization values properly
            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role
            );

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // 30-minute local expiration window
            };

            // Trigger the cookie authentication sign-in process
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties
            );

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Register(model);

            if (result)
                return RedirectToAction("Login");

            ModelState.AddModelError("", "Registration Failed. Email might already exist.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _tokenService.ClearTokens();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}