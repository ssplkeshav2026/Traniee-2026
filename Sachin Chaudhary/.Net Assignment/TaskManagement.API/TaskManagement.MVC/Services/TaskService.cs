using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly IApiService _apiService;

        public TaskService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<TaskViewModel>> GetAllTasks()
        {
            var response = await _apiService.GetAsync("api/tasks");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TaskViewModel>>(content) ?? new List<TaskViewModel>();
            }
            return new List<TaskViewModel>();
        }

        public async Task<TaskViewModel?> GetTaskById(int id)
        {
            var response = await _apiService.GetAsync($"api/tasks/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TaskViewModel>(content);
            }
            return null;
        }

        public async Task<bool> CreateTask(TaskViewModel task)
        {
            var json = JsonConvert.SerializeObject(task);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("api/tasks", content);
            return response.IsSuccessStatusCode;
        }
    }
}