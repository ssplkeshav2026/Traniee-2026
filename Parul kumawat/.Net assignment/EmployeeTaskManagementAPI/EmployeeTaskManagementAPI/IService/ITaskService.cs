using EmployeeTaskManagementAPI.Dto.TasksDto;
using EmployeeTaskManagementAPI.Models;

namespace EmployeeTaskManagementAPI.IService
{
    public interface ITaskService
    {
        Task<List<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskById(int id);
        Task<string> CreateTaskAsync(CreateTaskDto dto, string assignBy);
        Task<string> UpdateTaskAsync(int id, UpdateTaskDto dto);

        Task<string> DeleteTaskAsync(int id);
        Task<List<Tasks>> GetMyTasksAsync(string userId);

        Task<string> UpdateTaskStatusAsync(int taskId, string userId, UpdateTaskStatusDto dto);
    }
}
