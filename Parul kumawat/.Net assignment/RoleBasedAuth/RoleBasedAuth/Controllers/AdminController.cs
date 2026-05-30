using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Data;
using RoleBasedAuth.Models.ViewModel;
using System.Data;

namespace RoleBasedAuth.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var users = _userManager.Users.ToList();

            var model = new List<UserViewModel>();

            foreach (var data in users)
            {


                if(data.Email == "admin@gmail.com")
                {
                    continue;
                }
                var roles = await _userManager.GetRolesAsync(data);

               
                    model.Add(new UserViewModel
                    {
                        Id = data.Id,
                        Email = data.Email,
                        Status = data.Status,
                        Name = data.Name,
                        Age = data.Age,
                        SelectedUsersRoles = roles.ToList(),
                        Roles = new List<string> { "Admin", "User", "Manager", "HR" }
                       

                    });
                
            }
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                return NotFound();
            }

            user.Status = model.Status;
            await _userManager.UpdateAsync(user);

            var oldRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, oldRoles);

            if(model.SelectedUsersRoles != null)
            {
                await _userManager.AddToRolesAsync(user, model.SelectedUsersRoles);

            }

            return RedirectToAction("Dashboard");
        }
    }
}
