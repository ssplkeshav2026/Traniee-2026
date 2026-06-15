using EmployeeTaskManagementAPI.Data;
using EmployeeTaskManagementAPI.Dto.TasksDto;
using EmployeeTaskManagementAPI.Enum;
using EmployeeTaskManagementAPI.IService;
using EmployeeTaskManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TaskService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<string> CreateTaskAsync(CreateTaskDto dto, string assignBy)
        {
              var task = new Tasks
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    AssignedToUserId = dto.AssignedToUserId,
                    AssignedByUserId = assignBy,
                    Status = TasksStatus.Pending.ToString(),
                    DueDate = dto.DueDate,
                    CreatedDate = DateTime.UtcNow

                };
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
                return "task created successfully";

            
        }

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if(task == null)
                {
                    throw new Exception("task does not exist of this id");
                }
                return task;
            
            
        }

        public async Task<string> UpdateTaskAsync(int id, UpdateTaskDto dto)
        {
            
                var isTaskExist = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (isTaskExist == null)
                {
                    return "task does not exist of this id";
                }
                isTaskExist.Title = dto.Title;
                isTaskExist.Description = dto.Description;
                isTaskExist.DueDate = dto.DueDate;

                await _context.SaveChangesAsync();
                return "task updated successfully";

            
        }
        
        public async Task<string> DeleteTaskAsync(int id)
        {
           
                var isTaskExist = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (isTaskExist == null)
                {
                    return "task does not exist of this id";
                }
                 _context.Tasks.Remove(isTaskExist);
                await _context.SaveChangesAsync();
                return "task deleted successfully";

            }
          
        

        public async Task<List<Tasks>> GetMyTasksAsync(string userId)
        {
            var tasks = await _context.Tasks.Where(x => x.AssignedToUserId == userId).ToListAsync();
            return tasks;
        }

        public async Task<string> UpdateTaskStatusAsync(int taskId, string userId, UpdateTaskStatusDto dto)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskId && x.AssignedToUserId == userId);

            if (task == null)
            {
                return "Task not found";
            }

            task.Status = dto.Status.ToString();
            task.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return "Status updated successfully";
        }
    }
}
