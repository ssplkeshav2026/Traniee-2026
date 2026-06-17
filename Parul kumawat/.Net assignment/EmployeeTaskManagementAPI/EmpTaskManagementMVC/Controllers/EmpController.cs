using EmployeeTaskManagementAPI.Enum;
using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpTaskManagementMVC.Controllers
{
    [Authorize(Roles = "Employee")]

    public class EmpController : Controller
    {
        private readonly IMvcTasksService _tasksService;
        public EmpController(IMvcTasksService tasksService)
        {
            _tasksService = tasksService;
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTaskStatus(int id)
        {
            var task = await _tasksService.GetTaskByIdAsync(id);

            if (Enum.TryParse<TasksStatus>(task.Status, ignoreCase: true, out TasksStatus parsedStatus))
            {
                var model = new UpdateTaskStatusViewModel
                {
                    Id = id,
                    Status = parsedStatus
                };
                return View(model);

            }
            else
            {
                var model = new UpdateTaskStatusViewModel
                {
                    Id = id,
                    Status = TasksStatus.Pending
                };
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyTasks()
        {
            try
            {
                var tasks = await _tasksService.GetMyTasksAsync();
                if (tasks == null)
                {
                    return RedirectToAction("MyTasks");
                }
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


        [HttpPost]
        public async Task<IActionResult> UpdateTaskStatus(int id, UpdateTaskStatusViewModel model)
        {
            try
            {
                var response = await _tasksService.UpdateTaskStatusAsync(id, model);

                return RedirectToAction("MyTasks");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("MyTasks");
            }
        }

    }
}
