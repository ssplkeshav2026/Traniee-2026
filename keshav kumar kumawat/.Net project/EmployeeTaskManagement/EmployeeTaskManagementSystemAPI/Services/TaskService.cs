using EmployeeTaskManagementSystemAPI.Data;
using EmployeeTaskManagementSystemAPI.Dto;
using EmployeeTaskManagementSystemAPI.IServices;
using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystemAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            return tasks.ToList();
        }
        public async Task<List<TaskItem>> GetMyTasksAsync(string userId)
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();

            return tasks
                .Where(x => x.AssignedToUserId == userId)
                .ToList();
        }
        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _unitOfWork.Tasks.GetByIdAsync(id);
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

            await _unitOfWork.Tasks.AddAsync(task);

            await _unitOfWork.SaveAsync();

            return task;
        }
        public async Task<bool> UpdateTaskAsync(int id,TaskUpdateDto dto,string userId,string role)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);

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
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);

            if (task == null)
                return false;

            _unitOfWork.Tasks.Delete(task);

            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
