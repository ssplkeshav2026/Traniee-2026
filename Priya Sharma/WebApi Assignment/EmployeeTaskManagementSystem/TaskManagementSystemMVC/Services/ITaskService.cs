using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public interface ITaskService
    {
        Task<List<TaskViewModel>> GetAllTasksAsync();
        Task<TaskViewModel?> GetTaskByIdAsync(int id);
        Task<bool> CreateTaskAsync(CreateTaskViewModel model);
        Task<bool> UpdateTaskAsync(int id, EditTaskViewModel model);
        Task<bool> DeleteTaskAsync(int id);
        Task<List<TaskViewModel>> GetMyTasksAsync();
    }
}
