using IdentityProject.Data;
using IdentityProject.Models;
using IdentityProject.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Register

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
                //throw new Exception("Testing exception");

                if (ModelState.IsValid)
                {
                    string? fileName = null;

                    if (model.ProfileImage != null)
                    {
                        string uploadFolder = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/profile"
                        );

                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);

                        string filePath = Path.Combine(uploadFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfileImage.CopyToAsync(stream);
                        }
                    }

                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        IsActive = true,
                        ProfilePicture = fileName
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong during the registration");
                return View(model);
            }

        }


        // Login

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
                //throw new Exception("Testing exception");

                if (ModelState.IsValid)
                {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // Check User Active or Not
                    if (!user.IsActive)
                    {
                        ModelState.AddModelError(string.Empty, "Your account is inactive.");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(
                        user,
                        model.Password,
                        model.RememberMe,
                        false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Email or Password");

                //ViewBag.Message = "Invalid Email or Password";
            }

            return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong during the Login");
                return View(model);
            }
        }

        // Logout

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        // Access Denied
        public IActionResult AccessDenied()
        {
            return View();
        }
        //Change Password
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    model.CurrentPassword,
                    model.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    ViewBag.Message = "Password changed successfully.";
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "Something went wrong during the ChangePassword");
                return View(model);
            }
        }

        // Profile Photo
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new ProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            if (model.ProfileImage != null)
            {
                string uploadFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/profile"
                );

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);

                string filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                user.ProfilePicture = fileName;
                model.ProfilePicture = fileName;
            }
            else
            {
                model.ProfilePicture = user.ProfilePicture;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                ViewBag.Message = "Profile updated successfully.";
                return View(model);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

    }
}