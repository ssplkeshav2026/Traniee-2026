using identity.Data;
using identity.Models;
using identity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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
                Console.WriteLine($"Remember Me = {model.RememberMe}");
                var user =
                    await _userManager.FindByEmailAsync(
                        model.Email);

                if (user != null && user.IsActive)
                {
                    var result =await _signInManager.PasswordSignInAsync( 
                        user.UserName,
                        model.Password, 
                        model.RememberMe,false);


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

        // CHANGE PASSWORD PAGE
        public IActionResult ChangePassword()
        {
            return View();
        }

        // CHANGE PASSWORD POST
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Current logged in user
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
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    ViewBag.Message = "Password changed successfully";
                    return RedirectToAction("Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("ChangePassword");
        
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        // PROFILE PAGE
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login");

            var model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                ExistingImage = user.ProfilePicture
            };

            return View(model);
        }

        // PROFILE UPDATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;

            if (model.ProfileImage != null)
            {
                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "ProfileImages");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(model.ProfileImage.FileName);

                string filePath =
                    Path.Combine(folderPath, fileName);

                using (var stream =
                       new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                user.ProfilePicture = fileName;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                ViewBag.Message = "Profile Updated Successfully";
            }

            model.ExistingImage = user.ProfilePicture;

            return RedirectToAction("Profile");
        }
    }
}