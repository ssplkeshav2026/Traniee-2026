using EmployeeTaskManagementSystemAPI.Data;
using EmployeeTaskManagementSystemAPI.Dto;
using EmployeeTaskManagementSystemAPI.IServices;
using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystemAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<List<TaskItem>> GetMyTasksAsync(string userId)
        {
            return await _context.Tasks
                .Where(x => x.AssignedToUserId == userId)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskCreateDto dto,string assignedByUserId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                AssignedToUserId = dto.AssignedToUserId,
                AssignedByUserId = assignedByUserId,
                Status = "Pending",
                DueDate = dto.DueDate,
                CreatedDate = DateTime.Now
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateTaskAsync(int id,TaskUpdateDto dto,string userId,string role)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
                return false;

            if (role == "Employee")
            {
                if (task.AssignedToUserId != userId)
                    return false;

                task.Status = dto.Status;
            }
            else
            {
                task.Title = dto.Title;
                task.Description = dto.Description;
                task.AssignedToUserId = dto.AssignedToUserId;
                task.Status = dto.Status;
                task.DueDate = dto.DueDate;
                task.UpdatedDate = DateTime.Now;
            }
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
