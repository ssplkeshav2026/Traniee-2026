using Microsoft.EntityFrameworkCore;
using TaskManagementSystemApi.Data;
using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskDto>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.AssignedBy)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status.ToString(),
                    DueDate = t.DueDate,
                    CreatedDate = t.CreatedDate,
                    UpdatedDate = t.UpdatedDate,
                    AssignedToUserId = t.AssignedToUserId,
                    AssignedToName = t.AssignedTo != null
                                       ? t.AssignedTo.FirstName + " " + t.AssignedTo.LastName
                                       : null,
                    AssignedByUserId = t.AssignedByUserId,
                    AssignedByName = t.AssignedBy != null
                                       ? t.AssignedBy.FirstName + " " + t.AssignedBy.LastName
                                       : null
                })
                .ToListAsync();
        }

        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.AssignedBy)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                DueDate = task.DueDate,
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate,
                AssignedToUserId = task.AssignedToUserId,
                AssignedToName = task.AssignedTo != null
                                   ? task.AssignedTo.FirstName + " " + task.AssignedTo.LastName
                                   : null,
                AssignedByUserId = task.AssignedByUserId,
                AssignedByName = task.AssignedBy != null
                                   ? task.AssignedBy.FirstName + " " + task.AssignedBy.LastName
                                   : null
            };
        }

        public async Task<List<TaskDto>> GetMyTasksAsync(string userId)
        {
            return await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.AssignedBy)
                .Where(t => t.AssignedToUserId == userId)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status.ToString(),
                    DueDate = t.DueDate,
                    CreatedDate = t.CreatedDate,
                    UpdatedDate = t.UpdatedDate,
                    AssignedToUserId = t.AssignedToUserId,
                    AssignedToName = t.AssignedTo != null
                                       ? t.AssignedTo.FirstName + " " + t.AssignedTo.LastName
                                       : null,
                    AssignedByUserId = t.AssignedByUserId,
                    AssignedByName = t.AssignedBy != null
                                       ? t.AssignedBy.FirstName + " " + t.AssignedBy.LastName
                                       : null
                })
                .ToListAsync();
        }

        public async Task CreateTaskAsync(CreateTaskDto dto, string assignedByUserId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                AssignedToUserId = dto.AssignedToUserId,
                AssignedByUserId = assignedByUserId,
                Status = TaskitemStatus.Pending,
                DueDate = dto.DueDate,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(
            int taskid, UpdateTaskDto dto, string userId, string userRole)
        {
            var task = await _context.Tasks.FindAsync(taskid);

            if (task == null)
                throw new KeyNotFoundException($"Task {taskid} not found");

            if (userRole == "Employee")
            {
                if (task.AssignedToUserId != userId)
                    throw new UnauthorizedAccessException(
                        "You can only update your own task");

                task.Status = dto.Status;
                task.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return;
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.AssignedToUserId = dto.AssignedToUserId;
            task.Status = dto.Status;
            task.DueDate = dto.DueDate;
            task.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskStatusAsync(int id, string status)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                throw new KeyNotFoundException("Task not found");

            if (Enum.TryParse<TaskitemStatus>(status, true, out var taskStatus))
            {
                task.Status = taskStatus;
            }
            else
            {
                throw new Exception("Invalid status value.");
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                throw new KeyNotFoundException($"Task {id} not found");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}