using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemMVC.Services;
using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TaskController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return View(tasks);
        }

        
        [HttpGet]
        public async Task<IActionResult> MyTasks()
        {
            var tasks = await _taskService.GetMyTasksAsync();
            return View(tasks);
        }

       
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();
            return View(task);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAllUsersAsync();
            ViewBag.Users = users;
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = await _userService.GetAllUsersAsync();
                return View(model);
            }

            var success = await _taskService.CreateTaskAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to create task");
                ViewBag.Users = await _userService.GetAllUsersAsync();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            var users = await _userService.GetAllUsersAsync();
            ViewBag.Users = users;

            var model = new EditTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssignedToUserId = task.AssignedToUserId,
                Status = task.Status == "Pending" ? "pending"
                                 : task.Status == "InProgress" ? "inprogress"
                                 : "completed",
                DueDate = task.DueDate
            };

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = await _userService.GetAllUsersAsync();
                return View(model);
            }

            var success = await _taskService.UpdateTaskAsync(id, model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to update task");
                ViewBag.Users = await _userService.GetAllUsersAsync();
                return View(model);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await _taskService.UpdateTaskStatusAsync(id, status);

            //TempData["Success"] = "Task status updated successfully.";

            return RedirectToAction(nameof(MyTasks));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            return Json(new { success });
        }
    }
}
