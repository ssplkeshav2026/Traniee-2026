using identity.Data;
using identity.Models;
using identity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<identityUser> _userManager;
        private readonly SignInManager<identityUser> _signInManager;

        public AccountController(
            UserManager<identityUser> userManager,
            SignInManager<identityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                identityUser user = new identityUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    IsActive = true
                };

                var result =
                    await _userManager.CreateAsync(
                        user,
                        model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(
                        user, "Member");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        "",
                        error.Description);
                }
            }

            return View(model);
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =
                    await _userManager.FindByEmailAsync(
                        model.Email);

                if (user != null && user.IsActive)
                {
                    var result =
                        await _signInManager.PasswordSignInAsync(
                            user.UserName,
                            model.Password,
                            false,
                            false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(
                            "Index",
                            "Home");
                    }
                }

                ModelState.AddModelError(
                    "",
                    "Invalid Login");
            }

            return View(model);
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}