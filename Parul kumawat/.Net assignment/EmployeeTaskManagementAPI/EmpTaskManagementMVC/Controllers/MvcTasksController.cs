using EmployeeTaskManagementAPI.Enum;
using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EmpTaskManagementMVC.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class MvcTasksController : Controller
    {
        private readonly IMvcTasksService _tasksService;
        private readonly IMvcUsersService _usersService;
        public MvcTasksController(IMvcTasksService tasksService, IMvcUsersService usersService)
        {
            _tasksService = tasksService;
            _usersService = usersService;
        }
        [Authorize(Roles = "Admin,Manager")]

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                var model = new CreateTaskViewModel();

                await _tasksService.ValidateSessionAsync();
                var users = await _usersService.GetAllUsersAsync(); 

                model.Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                }).ToList();

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "MvcAuth");
            }
        }
            
        
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _tasksService.GetTaskByIdAsync(id);
            return View(task);
        }

        
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var task = await _tasksService.GetTaskByIdAsync(id);

                var model = new UpdateTaskViewModel
                {
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate
                };

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel taskModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(taskModel);

                }
                string response = await _tasksService.CreateTaskAsync(taskModel);
                if (!string.IsNullOrEmpty(response))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Task creation failed");

                return View(taskModel);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(taskModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateTaskViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var response = await _tasksService.UpdateTaskAsync(id, model);

                if (!string.IsNullOrEmpty(response))
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Task update failed");

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var tasks = await _tasksService.GetAllTasksAsync();

                return View(tasks);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(new List<TaskViewModel>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var task = await _tasksService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return RedirectToAction("Index");
                }
                return View(task);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(new TaskViewModel());
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var response = await _tasksService.DeleteTaskAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Login", "MvcAuth");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(CreateTaskViewModel taskModel)
        //{
        //    try
        //    {
        //        var result = await _tasksService.CreateTaskAsync(taskModel);

        //        return Json(new
        //        {
        //            success = true,
        //            message = result
        //        });
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        return RedirectToAction("Login", "MvcAuth");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = ex.Message
        //        });
        //    }
        //}

    }
}
