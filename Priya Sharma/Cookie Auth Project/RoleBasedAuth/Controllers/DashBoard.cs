using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Models.Domain;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;
using RoleBasedAuth.Authorization;

namespace RoleBasedAuth.Controllers
{
    //[Authorize(Roles="Admin")]
    [CustomEmail]
    public class DashBoard : Controller
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        public DashBoard(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            RoleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var users = await _userManager.Users.ToListAsync();



            var model = new List<ManageUser>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                model.Add(new ManageUser
                {
                    UserId = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Status = item.Status,
                    UserRoles = roles.ToList(),
                });
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoles(List<ManageUser> model)
        {
            try {
                foreach (var item in model)
                {
                    var user = await _userManager.FindByIdAsync(item.UserId);

                    if (user == null)
                        continue;

                    var existingRoles = await _userManager.GetRolesAsync(user);

                    await _userManager.RemoveFromRolesAsync(user, existingRoles);

                    if (item.UserRoles != null)
                    {
                        await _userManager.AddToRolesAsync(user, item.UserRoles);
                    }
                }
                TempData["SuccessMessage"] ="Roles updated successfully.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Updation Fails..." + ex.Message;

                return RedirectToAction("DashBoard");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ToggleStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.Status = !user.Status;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }
}
