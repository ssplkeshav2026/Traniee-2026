using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EmpTaskManagementMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MvcUsersController : Controller
    {
        private readonly IMvcUsersService _usersService;
        public MvcUsersController(IMvcUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return RedirectToAction("Index");

                var user = await _usersService.GetUserByIdAsync(id);

                if (user == null)
                {
                    TempData["Error"] = "User not found";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await _usersService.GetUserByIdAsync(id);
                if (user == null)
                {
                    TempData["Error"] = "User not found";
                    return RedirectToAction("Index");
                }
                var model = new UpdateUserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
                try
                {
                    var users = await _usersService.GetAllUsersAsync();
                    return View(users);
                }
               
            
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(new List<UsersViewModel>());
                }

            }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var users = await _usersService.GetUserByIdAsync(id);
                if (users == null || string.IsNullOrEmpty(users.Id))
                {
                    ModelState.AddModelError("","User not found");
                    return RedirectToAction("Index");
                }
                return View(users);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    TempData["Error"] = "Invalid user id";
                    return RedirectToAction("Index");
                }

                var result = await _usersService.DeleteUserAsync(id);

                TempData["msg"] = result;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _usersService.UpdateUserAsync(model);

            TempData["msg"] = result;

            return RedirectToAction("Index");
        }

        
    }
    }

