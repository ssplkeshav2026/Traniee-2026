using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs.Dashboard;
using TaskManagement.API.Models;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var userId = User.FindFirst("UserId")?.Value;

            var query = _context.EmployeeTasks.AsQueryable();

            if (User.IsInRole("Employee"))
            {
                query = query.Where(t => t.AssignedToUserId == userId);
            }

            var today = DateTime.UtcNow.Date;

            var totalTasks = await query.CountAsync();

            var completedTasks = await query
                .CountAsync(t => t.Status == TaskStatusType.Completed);

            var completionRate = totalTasks == 0
                ? 0
                : Math.Round((double)completedTasks / totalTasks * 100, 2);

            var totalUsers = await _userManager.Users.CountAsync();

            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            var employees = await _userManager.GetUsersInRoleAsync("Employee");

            var tasksCompletedToday = await query.CountAsync(t =>
                t.Status == TaskStatusType.Completed &&
                t.UpdatedDate != null &&
                t.UpdatedDate.Value.Date == today);

            var tasksPendingToday = await query.CountAsync(t =>
                t.Status == TaskStatusType.Pending &&
                t.CreatedDate.Date == today);

            var recentTasks = await query
                .Include(t => t.AssignedToUser)
                .OrderByDescending(t => t.CreatedDate)
                .Take(5)
                .Select(t => new RecentTaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    AssignedToUserName = t.AssignedToUser == null
                        ? ""
                        : t.AssignedToUser.FirstName + " " + t.AssignedToUser.LastName,
                    Status = t.Status.ToString(),
                    DueDate = t.DueDate
                })
                .ToListAsync();

            var stats = new DashboardStatsDto
            {
                TotalTasks = totalTasks,
                PendingTasks = await query.CountAsync(t => t.Status == TaskStatusType.Pending),
                InProgressTasks = await query.CountAsync(t => t.Status == TaskStatusType.InProgress),
                CompletedTasks = completedTasks,

                TotalUsers = totalUsers,
                TotalManagers = managers.Count,
                TotalEmployees = employees.Count,
                TaskCompletionRate = completionRate,
                TasksCompletedToday = tasksCompletedToday,
                TasksPendingToday = tasksPendingToday,

                RecentTasks = recentTasks
            };

            return Ok(stats);
        }
    }
}