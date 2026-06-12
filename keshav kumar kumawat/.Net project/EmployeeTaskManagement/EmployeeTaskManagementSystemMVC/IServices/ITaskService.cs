using EmployeeTaskManagementSystemMVC.ViewModels;

namespace EmployeeTaskManagementSystemMVC.IServices
{
    public interface ITaskService
    {
        Task<List<TaskVM>> GetAllTasksAsync();
        Task<List<TaskVM>> GetMyTasksAsync();
        Task<TaskVM?> GetTaskByIdAsync(int id);

        Task<bool> CreateTaskAsync(TaskCreateVM model);
        Task<bool> UpdateTaskAsync(int id, TaskUpdateVM model);
        Task<bool> DeleteTaskAsync(int id);
    }
}
