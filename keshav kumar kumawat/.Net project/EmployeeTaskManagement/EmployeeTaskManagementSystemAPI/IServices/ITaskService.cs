using EmployeeTaskManagementSystemAPI.Dto;
using EmployeeTaskManagementSystemAPI.Models;

namespace EmployeeTaskManagementSystemAPI.IServices
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<List<TaskItem>> GetMyTasksAsync(string userId);
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskCreateDto dto, string assignedByUserId);
        Task<bool> UpdateTaskAsync(int id, TaskUpdateDto dto, string userId, string role);
        Task<bool> DeleteTaskAsync(int id);
    }
}
