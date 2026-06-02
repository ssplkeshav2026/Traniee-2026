using IdentityProject.Data;
using IdentityProject.Models;
using IdentityProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace IdentityProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // PROFILE DETAILS PAGE
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ExistingProfilePicture = user.ProfilePicture
            };

            return View(model);
        }

        // EDIT PROFILE PAGE
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ExistingProfilePicture = user.ProfilePicture
            };

            return View(model);
        }

        // UPDATE PROFILE
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    // IMAGE UPLOAD
                    if (model.ProfilePicture != null)
                    {
                        string fileName =
                            Guid.NewGuid().ToString() +
                            Path.GetExtension(
                                model.ProfilePicture.FileName);

                        string uploadFolder = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images");

                        string filePath =
                            Path.Combine(uploadFolder, fileName);

                        using (var stream =
                               new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfilePicture
                                .CopyToAsync(stream);
                        }

                        user.ProfilePicture = fileName;
                    }

                    await _userManager.UpdateAsync(user);

                    TempData["Success"] =
                        "Profile updated successfully.";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occurred while updating the profile: " + ex.Message);
            }
            return View(model);
        }

        // CHANGE PASSWORD PAGE
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // CHANGE PASSWORD
        [HttpPost]
        public async Task<IActionResult> ChangePassword(
            ChangePasswordViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var user =
                        await _userManager.GetUserAsync(User);

                    var result =
                        await _userManager.ChangePasswordAsync(
                            user,
                            model.CurrentPassword,
                            model.NewPassword);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(
                            user,
                            isPersistent: false);

                        ViewBag.message =
                            "Password changed successfully.";

                        return View();
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(
                            string.Empty,
                            error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occurred while changing the password: " + ex.Message);
            }
            return View(model);
        }
    }
}