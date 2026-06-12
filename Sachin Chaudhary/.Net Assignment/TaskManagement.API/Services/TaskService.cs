using Microsoft.EntityFrameworkCore;

using TaskManagement.API.DTOs;
using TaskManagement.API.Models;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskResponseDto>> GetAllAsync()
        {
            return await _context.Tasks
                .Select(x => new TaskResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    AssignedToUserId = x.AssignedToUserId,
                    AssignedByUserId = x.AssignedByUserId,
                    Status = x.Status,
                    DueDate = x.DueDate,
                    CreatedDate = x.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<TaskResponseDto> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .Where(x => x.Id == id)
                .Select(x => new TaskResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    AssignedToUserId = x.AssignedToUserId,
                    AssignedByUserId = x.AssignedByUserId,
                    Status = x.Status,
                    DueDate = x.DueDate,
                    CreatedDate = x.CreatedDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TaskResponseDto> CreateAsync(
            CreateTaskDto dto,
            string assignedByUserId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                AssignedToUserId = dto.AssignedToUserId,
                AssignedByUserId = assignedByUserId,
                Status = "Pending",
                DueDate = dto.DueDate,
                CreatedDate = DateTime.UtcNow
            };

            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();

            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssignedToUserId = task.AssignedToUserId,
                AssignedByUserId = task.AssignedByUserId,
                Status = task.Status,
                DueDate = task.DueDate,
                CreatedDate = task.CreatedDate
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateTaskDto dto)
        {
            var task =
                await _context.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
                return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.DueDate = dto.DueDate;
            task.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task =
                await _context.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}