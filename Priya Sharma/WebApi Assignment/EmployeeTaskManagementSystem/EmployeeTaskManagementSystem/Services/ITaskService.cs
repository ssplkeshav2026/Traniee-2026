using TaskManagementSystemApi.DTOs;
using TaskManagementSystemApi.Models;

namespace TaskManagementSystemApi.Services
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasksAsync();

        Task<TaskDto> GetTaskByIdAsync(int id);

        Task CreateTaskAsync(CreateTaskDto dto, string assignedByUserId);

        Task UpdateTaskAsync(int taskid, UpdateTaskDto dto, string userId,string userRole);
        Task UpdateTaskStatusAsync(int id, string status);

        Task DeleteTaskAsync(int id);

        Task<List<TaskDto>> GetMyTasksAsync(string UserId);
    }
}
