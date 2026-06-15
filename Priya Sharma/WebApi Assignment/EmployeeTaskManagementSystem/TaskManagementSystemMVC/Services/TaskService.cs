using TaskManagementSystemMVC.Helper;
using TaskManagementSystemMVC.ViewModel;

namespace TaskManagementSystemMVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApiService _apiService;

        public TaskService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<TaskViewModel>> GetAllTasksAsync()
        {
            return await _apiService
                       .GetAsync<List<TaskViewModel>>("api/Task")
                   ?? new List<TaskViewModel>();
        }

        public async Task<TaskViewModel?> GetTaskByIdAsync(int id)
        {
            return await _apiService.GetAsync<TaskViewModel>($"api/Task/{id}");
        }

        public async Task<List<TaskViewModel>> GetMyTasksAsync()
        {
            return await _apiService
                       .GetAsync<List<TaskViewModel>>("api/Task/my-tasks")
                   ?? new List<TaskViewModel>();
        }

        public async Task<bool> CreateTaskAsync(CreateTaskViewModel model)
        {
            try
            {
                await _apiService.PostAsync("api/Task", new
                {
                    title = model.Title,
                    description = model.Description,
                    assignedToUserId = model.AssignedToUserId,
                    dueDate = model.DueDate
                });
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateTaskAsync(int id, EditTaskViewModel model)
        {
            return await _apiService.PutAsync($"api/Task/{id}", new
            {
                title = model.Title,
                description = model.Description,
                assignedToUserId = model.AssignedToUserId,
                status = model.Status,
                dueDate = model.DueDate
            });
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _apiService.DeleteAsync($"api/Task/{id}");
        }
    }
}
