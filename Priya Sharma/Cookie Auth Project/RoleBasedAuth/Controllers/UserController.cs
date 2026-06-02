using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Models.Domain;
using RoleBasedAuth.Models.DTO;
using System.Linq.Expressions;

namespace RoleBasedAuth.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        Name = model.Name,
                        Email = model.Email,
                        UserName = model.Email,
                        Status = true
                    };
                    if (model.ProfileImage != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);

                        string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images",fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await model.ProfileImage.CopyToAsync(stream);
                        }

                        user.ProfilePicture = "/images/" + fileName;
                    }
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                        return RedirectToAction("Login");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Please Register Properly.");

                }
            }
                return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user == null)
                    {
                        ModelState.AddModelError("", "Invalid Email or Password");
                        return View(model);
                    }


                    if (user.Status == false)
                    {
                        ModelState.AddModelError("", "Your account is no longer active....");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(
                            user.UserName,
                            model.Password,
                            model.RememberMe,
                            false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Invalid Email or Password");

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Login Process is Wrong.");

                }
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                try {
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
                        TempData["Success"] = "Password Changed Successfully";

                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Change Your Password Properly.");

                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager .GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditDetails()
        {
            var user = await _userManager
                .GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var model =
                new EditProfile
                {
                    Name = user.Name,
                    Email = user.Email,
                    ExistingProfilePicture = user.ProfilePicture

                };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(EditProfile model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction( "Login");
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.Email;

            if (model.ProfileImage != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension( model.ProfileImage.FileName);

                string path = Path.Combine( Directory.GetCurrentDirectory(),
                        "wwwroot/images",
                        fileName);

                using (var stream =
                       new FileStream(
                           path,
                           FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                user.ProfilePicture = "/images/" + fileName;
            }

            var result = await _userManager .UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("EditProfile");
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch(Exception)
            {
                return RedirectToAction("Login");

            }
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
