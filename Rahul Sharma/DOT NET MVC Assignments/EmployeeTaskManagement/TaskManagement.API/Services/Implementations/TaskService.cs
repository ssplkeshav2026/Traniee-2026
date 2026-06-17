using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs.Tasks;
using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;
using TaskManagement.API.Helpers.Exceptions;

namespace TaskManagement.API.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskResponseDto>> GetAllTasksAsync(ClaimsPrincipal user)
        {
            var userId = GetUserId(user);

            IQueryable<EmployeeTask> query = _context.EmployeeTasks
                .Include(t => t.AssignedToUser)
                .Include(t => t.AssignedByUser);

            if (user.IsInRole("Employee"))
            {
                query = query.Where(t => t.AssignedToUserId == userId);
            }

            var tasks = await query
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();

            return tasks.Select(MapToDto).ToList();
        }

        public async Task<TaskResponseDto> GetTaskByIdAsync(int id, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);

            var task = await _context.EmployeeTasks
                .Include(t => t.AssignedToUser)
                .Include(t => t.AssignedByUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                throw new NotFoundException("Task not found.");

            if (user.IsInRole("Employee") && task.AssignedToUserId != userId)
                throw new ForbiddenException("Only Admin can delete tasks.");

            return MapToDto(task);
        }

        public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskRequestDto request, ClaimsPrincipal user)
        {
            if (!user.IsInRole("Admin") && !user.IsInRole("Manager"))
                throw new UnauthorizedAccessException("Only Admin and Manager can create tasks.");

            var assignedByUserId = GetUserId(user);

            var assignedUserExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToUserId);

            if (!assignedUserExists)
                throw new KeyNotFoundException("Assigned user not found.");

            var task = new EmployeeTask
            {
                Title = request.Title,
                Description = request.Description,
                AssignedToUserId = request.AssignedToUserId,
                AssignedByUserId = assignedByUserId,
                DueDate = request.DueDate,
                CreatedDate = DateTime.UtcNow
            };

            await _context.EmployeeTasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return await GetTaskByIdAsync(task.Id, user);
        }

        public async Task<TaskResponseDto> UpdateTaskAsync(int id, UpdateTaskRequestDto request, ClaimsPrincipal user)
        {
            if (!user.IsInRole("Admin") && !user.IsInRole("Manager"))
                throw new NotFoundException("Task not found.");

            var task = await _context.EmployeeTasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                throw new KeyNotFoundException("Task not found.");

            var assignedUserExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToUserId);

            if (!assignedUserExists)
                throw new KeyNotFoundException("Assigned user not found.");

            task.Title = request.Title;
            task.Description = request.Description;
            task.AssignedToUserId = request.AssignedToUserId;
            task.Status = request.Status;
            task.DueDate = request.DueDate;
            task.UpdatedDate = DateTime.UtcNow;

            _context.EmployeeTasks.Update(task);
            await _context.SaveChangesAsync();

            return await GetTaskByIdAsync(task.Id, user);
        }

        public async Task<TaskResponseDto> UpdateOwnTaskStatusAsync(
            int id,
            UpdateTaskStatusDto request,
            ClaimsPrincipal user)
        {
            var userId = GetUserId(user);

            var task = await _context.EmployeeTasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                throw new NotFoundException("Task not found.");

            if (user.IsInRole("Employee") && task.AssignedToUserId != userId)
                throw new UnauthorizedAccessException("You can only update your own assigned task status.");

            task.Status = request.Status;
            task.UpdatedDate = DateTime.UtcNow;

            _context.EmployeeTasks.Update(task);
            await _context.SaveChangesAsync();

            return await GetTaskByIdAsync(task.Id, user);
        }

        public async Task DeleteTaskAsync(int id, ClaimsPrincipal user)
        {
            if (!user.IsInRole("Admin"))
                throw new UnauthorizedAccessException("Only Admin can delete tasks.");

            var task = await _context.EmployeeTasks
                .FirstOrDefaultAsync(t => t.Id == id); 

            if (task == null)
                throw new KeyNotFoundException("Task not found.");

            _context.EmployeeTasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        private static string GetUserId(ClaimsPrincipal user)
        {
            var userId = user.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("Invalid token.");

            return userId;
        }

        private static TaskResponseDto MapToDto(EmployeeTask task)
        {
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssignedToUserId = task.AssignedToUserId,
                AssignedToUserName = task.AssignedToUser == null
                    ? string.Empty
                    : $"{task.AssignedToUser.FirstName} {task.AssignedToUser.LastName}",
                AssignedByUserId = task.AssignedByUserId,
                AssignedByUserName = task.AssignedByUser == null
                    ? string.Empty
                    : $"{task.AssignedByUser.FirstName} {task.AssignedByUser.LastName}",
                Status = task.Status,
                DueDate = task.DueDate,
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate
            };
        }
    }
}