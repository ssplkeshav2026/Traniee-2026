using EmpTaskManagementMVC.ViewModel.Tasks;

namespace EmpTaskManagementMVC.IService
{
    public interface IMvcTasksService
    {
        Task<List<TaskViewModel>> GetAllTasksAsync();

        Task<TaskViewModel> GetTaskByIdAsync(int id);

        Task<string> CreateTaskAsync(CreateTaskViewModel model);

        Task<string> UpdateTaskAsync(int id, UpdateTaskViewModel model);

        Task<string> DeleteTaskAsync(int id);

        Task<List<TaskViewModel>> GetMyTasksAsync();

        Task<string> UpdateTaskStatusAsync(int taskId,UpdateTaskStatusViewModel model);

        Task ValidateSessionAsync();

    }
}
