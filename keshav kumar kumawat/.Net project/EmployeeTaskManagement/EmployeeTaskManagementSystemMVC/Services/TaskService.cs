using EmployeeTaskManagementSystemMVC.Helpers;
using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.ViewModels;

namespace EmployeeTaskManagementSystemMVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService _authService;

        public TaskService(IHttpClientFactory httpClientFactory,IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        private async Task<HttpClient?> CreateClientWithTokenAsync()
        {
            var client = _httpClientFactory.CreateClient("TaskApi");

            var accessToken = _authService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
                return null;

            if (TokenHelper.IsTokenExpired(accessToken))
            {
                var refreshed = await _authService.RefreshAccessTokenAsync();

                if (!refreshed)
                    return null;

                accessToken = _authService.GetAccessToken();
            }

            client.DefaultRequestHeaders.Authorization =new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",accessToken);

            return client;
        }

        public async Task<List<TaskVM>> GetAllTasksAsync()
        {
            var client = await CreateClientWithTokenAsync();                 

            if (client == null)
                return new List<TaskVM>();

            var response = await client.GetAsync("api/tasks");

            if (!response.IsSuccessStatusCode)
                return new List<TaskVM>();

            var tasks = await response.Content.ReadFromJsonAsync<List<TaskVM>>();

            return tasks ?? new List<TaskVM>();
        }

        public async Task<List<TaskVM>> GetMyTasksAsync()
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return new List<TaskVM>();

            var response = await client.GetAsync("api/tasks/my-tasks");

            if (!response.IsSuccessStatusCode)
                return new List<TaskVM>();

            var tasks = await response.Content.ReadFromJsonAsync<List<TaskVM>>();

            return tasks ?? new List<TaskVM>();
        }

        public async Task<TaskVM?> GetTaskByIdAsync(int id)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return null;

            var response = await client.GetAsync($"api/tasks/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<TaskVM>();
        }

        public async Task<bool> CreateTaskAsync(TaskCreateVM model)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return false;

            var response = await client.PostAsJsonAsync("api/tasks", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTaskAsync(int id, TaskUpdateVM model)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return false;

            var response = await client.PutAsJsonAsync($"api/tasks/{id}", model);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var client = await CreateClientWithTokenAsync();

            if (client == null)
                return false;

            var response = await client.DeleteAsync($"api/tasks/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
