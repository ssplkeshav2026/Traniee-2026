using IdentityProject.CustomAttributes;
using IdentityProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Controllers
{
    [AdminEmailAuthorize]
    public class UserManagementController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

  

        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();

                var userList = new List<dynamic>();

                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    userList.Add(new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        Roles = roles,
                        user.IsActive
                    });
                }

                return View(userList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                TempData["Error"] = "Error loading users.";

                return View(new List<dynamic>());
            }
        }

    

        [HttpPost]
        public async Task<IActionResult> UpdateRole(string userId, List<string> roles)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                var oldRoles = await _userManager.GetRolesAsync(user);

           
                if (oldRoles.Any())
                {
                    await _userManager.RemoveFromRolesAsync(user, oldRoles);
                }

             
                if (roles != null && roles.Any())
                {
                    await _userManager.AddToRolesAsync(user, roles);
                }

                TempData["Success"] = "Role updated successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                TempData["Error"] = "Error updating role.";

                return RedirectToAction("Index");
            }
        }

     

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                user.IsActive = !user.IsActive;

                await _userManager.UpdateAsync(user);

                TempData["Success"] = "User status updated successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                TempData["Error"] = "Error updating user status.";

                return RedirectToAction("Index");
            }
        }
    }
}