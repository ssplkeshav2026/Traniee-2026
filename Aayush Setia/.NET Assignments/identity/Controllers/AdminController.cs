using identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace identity.Controllers

{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<identityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(
            UserManager<identityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
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
        [HttpPost]
        public async Task<IActionResult> UpdateRole(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            
            var oldRoles = await _userManager.GetRolesAsync(user);

            if (oldRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, oldRoles);
            }

            await _userManager.AddToRolesAsync(user, roles);


            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            user.IsActive = !user.IsActive;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }

}   

    

