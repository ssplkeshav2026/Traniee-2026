using IdentityDemo.Models;
using IdentityDemo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using IdentityDemo.CustomAttributes;

namespace IdentityDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalUsers = await userManager.Users.CountAsync(),

                ActiveUsers = await userManager.Users
                    .Where(x => x.Status == true)
                    .CountAsync(),

                TotalRoles = await roleManager.Roles.CountAsync(),

                TotalModules = 5
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AdminEmailAuthorize]
        public async Task<IActionResult> UsersList()
        {
            var users = await userManager.Users.ToListAsync();

            var model = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Status = user.Status,

                    Admin = roles.Contains("Admin"),
                    User = roles.Contains("User"),
                    Manager = roles.Contains("Manager"),
                    Employee = roles.Contains("Employee")
                });
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUsers(List<UserRoleViewModel> model)
        {
            foreach (var item in model)
            {
                var user = await userManager.FindByIdAsync(item.UserId);

                if (user == null)
                    continue;

                user.Status = item.Status;
                await userManager.UpdateAsync(user);

                var currentRoles = await userManager.GetRolesAsync(user);

                if (currentRoles.Any())
                {
                    await userManager.RemoveFromRolesAsync(user, currentRoles);
                }

                var selectedRoles = new List<string>();

                if (item.Admin) selectedRoles.Add("Admin");
                if (item.User) selectedRoles.Add("User");
                if (item.Manager) selectedRoles.Add("Manager");
                if (item.Employee) selectedRoles.Add("Employee");

                if (selectedRoles.Any())
                {
                    await userManager.AddToRolesAsync(user, selectedRoles);
                }
            }

            TempData["SuccessMessage"] = "Users updated successfully.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AdminEmailAuthorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
                TempData["SuccessMessage"] = "User deleted successfully.";
            }

            return RedirectToAction("UsersList");
        }

        public async Task<IActionResult> UsersDetails()
        {
            var users = await userManager.Users.ToListAsync();

            var model = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Status = user.Status,
                    ProfilePicture = user.ProfilePicture,

                    Admin = roles.Contains("Admin"),
                    User = roles.Contains("User"),
                    Manager = roles.Contains("Manager"),
                    Employee = roles.Contains("Employee")
                });
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                ExistingImage = user.ProfilePicture,
                ReturnUrl = Request.Headers["Referer"].ToString()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Status = model.Status;

            if (model.ProfileImage != null)
            {
                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/profiles"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                user.ProfilePicture = "/images/profiles/" + fileName;
            }

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "User details updated successfully.";

                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return RedirectToAction("EditUser", "Home", new { id = user.Id });
        }
    }
}