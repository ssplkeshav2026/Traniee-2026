using EmployeeTaskManagementSystemMVC.Filters;
using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementSystemMVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public TasksController(ITaskService taskService, IUserService userService, IAuthService authService)
        {
            _taskService = taskService;
            _userService = userService;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin" && role != "Manager")
                    return RedirectToAction("AccessDenied", "Auth");

                var tasks = await _taskService.GetAllTasksAsync();

                return View(tasks);
            }
            catch
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
        }

        public async Task<IActionResult> MyTasks()
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Employee")
                    return RedirectToAction("AccessDenied", "Auth");

                var tasks = await _taskService.GetMyTasksAsync();

                return View(tasks);
            }
            catch
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return View(task);
        }

        public async Task<IActionResult> Create()
        {
            var role = _authService.GetRole();

            if (role != "Admin" && role != "Manager")
                return RedirectToAction("AccessDenied", "Auth");

            var users = await _userService.GetUsersAsync();

            ViewBag.Users = users ?? new List<UserVM>();

            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Create(TaskCreateVM model)
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin" && role != "Manager")
                    return RedirectToAction("AccessDenied", "Auth");

                var result = await _taskService.CreateTaskAsync(model);

                if (!result)
                {
                    ModelState.AddModelError("", "Task create failed");

                    ViewBag.Users = await _userService.GetUsersAsync();

                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                ViewBag.Users = await _userService.GetUsersAsync();

                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = _authService.GetRole();

            if (role != "Admin" && role != "Manager" && role != "Employee")
            {
                return RedirectToAction("AccessDenied", "Auth");
            }


            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            if (role != "Employee")
            {
                ViewBag.Users = await _userService.GetUsersAsync();
            }


            var model = new TaskUpdateVM
            {
                Title = task.Title,
                Description = task.Description,
                AssignedToUserId = task.AssignedToUserId,
                Status = task.Status,
                DueDate = task.DueDate
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskUpdateVM model)
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin" && role != "Manager" && role != "Employee")
                    return RedirectToAction("AccessDenied", "Auth");

                var result = await _taskService.UpdateTaskAsync(id, model);

                if (!result)
                {
                    ModelState.AddModelError("", "Task update failed");

                    if (role != "Employee")
                    {
                        ViewBag.Users = await _userService.GetUsersAsync();
                    }

                    return View(model);
                }

                if (role == "Employee")
                {
                    return RedirectToAction("MyTasks");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                ViewBag.Users = await _userService.GetUsersAsync();

                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = _authService.GetRole();

                if (role != "Admin")
                    return RedirectToAction("AccessDenied", "Auth");

                await _taskService.DeleteTaskAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}