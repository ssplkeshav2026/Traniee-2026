using IdentityProject.Data;
using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser =
                        await _userManager.FindByEmailAsync(model.Email);

                    if (existingUser != null)
                    {
                        ModelState.AddModelError("",
                            "User already registered with this email.");

                        return View(model);
                    }

                    string fileName = null;

                    if (model.ProfilePicture != null)
                    {
                        string uploadFolder = Path.Combine(
                            _webHostEnvironment.WebRootPath,
                            "images");

                        fileName = Guid.NewGuid().ToString()
                                   + "_"
                                   + model.ProfilePicture.FileName;

                        string filePath =
                            Path.Combine(uploadFolder, fileName);

                        using (var fileStream =
                               new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfilePicture
                                .CopyToAsync(fileStream);
                        }
                    }

                    AppUser user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        IsActive = true,
                        ProfilePicture = fileName
                    };

                    var result =
                        await _userManager.CreateAsync(
                            user,
                            model.Password);

                    if (result.Succeeded)
                    {
                        TempData["Success"] =
                            "Registration successful. Please login.";

                        return RedirectToAction("Login");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",
                            error.Description);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    "Something went wrong during registration.");

                Console.WriteLine(ex.Message);

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user =
                        await _userManager.FindByEmailAsync(model.Email);

                    if (user != null && !user.IsActive)
                    {
                        ModelState.AddModelError("",
                            "Your account is inactive.");

                        return View(model);
                    }

                    var result =
                        await _signInManager.PasswordSignInAsync(
                            model.Email,
                            model.Password,
                            model.RememberMe,
                            false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("",
                        "Invalid Login Attempt");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    "Something went wrong during login.");

                Console.WriteLine(ex.Message);

                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}