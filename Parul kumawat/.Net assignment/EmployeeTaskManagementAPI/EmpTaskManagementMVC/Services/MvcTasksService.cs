using Azure;
using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.ViewModel.Tasks;
using System.Net.Http.Headers;

namespace EmpTaskManagementMVC.Services
{
    public class MvcTasksService : IMvcTasksService
    {

        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMvcAuthService _mvcAuthService;

        public MvcTasksService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IMvcAuthService mvcAuthService)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _mvcAuthService = mvcAuthService;
        }

        private async Task GetAccessToken()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var accessToken = session.GetString("AccessToken");
            var refreshToken = session.GetString("RefreshToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return;
            }
            if (string.IsNullOrEmpty(refreshToken))
            {
                return;
            }
            var accessTokenExpiryTime = await _mvcAuthService.GetAccessTokenExpireTime(accessToken);
            {

                if(accessTokenExpiryTime <= DateTime.UtcNow)
                {
                    try
                    {
                        var newToken = await _mvcAuthService.RefreshTokenAsync(refreshToken);
                        Console.WriteLine("OLD TOKEN: " + accessToken);
                        Console.WriteLine("NEW TOKEN: " + newToken.AccessToken);
                        session.SetString("AccessToken",newToken.AccessToken);

                        session.SetString("RefreshToken",newToken.RefreshToken);

                        accessToken = newToken.AccessToken;
                    }
                    catch(Exception)
                    {
                        session.Clear();
                        throw new UnauthorizedAccessException("Session Expired. Please Login Again.");
                    }
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
        public async Task<List<TaskViewModel>> GetAllTasksAsync()
        {
           await GetAccessToken();
            
            var response = await _httpClient.GetFromJsonAsync<List<TaskViewModel>>("/api/Task/getAllTasks");
            if (response == null)
            {
                return new List<TaskViewModel>();
            }
            return response;
        }

        public async Task<string> UpdateTaskStatusAsync(int taskId,UpdateTaskStatusViewModel model)
        {
            await GetAccessToken();

            var response = await _httpClient.PutAsJsonAsync($"/api/Task/update-status/{taskId}",model);

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<TaskViewModel> GetTaskByIdAsync(int id)
        {
            await GetAccessToken();
            var response = await _httpClient.GetFromJsonAsync<TaskViewModel>($"/api/Task/get/{id}");
            if(response == null)
            {
                return new TaskViewModel();
            }
            return response;

        }

        public async Task<string> CreateTaskAsync(CreateTaskViewModel taskModel)
        {
            await GetAccessToken();
            var response = await _httpClient.PostAsJsonAsync("/api/Task/create", taskModel);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteTaskAsync(int id)
        {
            await GetAccessToken();
            var response = await _httpClient.DeleteAsync($"/api/Task/delete/{id}");
            return await response.Content.ReadAsStringAsync();

        }
        public async Task<List<TaskViewModel>> GetMyTasksAsync()
        {
            await GetAccessToken();
            return await _httpClient.GetFromJsonAsync<List<TaskViewModel>>("/api/Task/myTasks") ?? new List<TaskViewModel>();
        }

        public async Task<string> UpdateTaskAsync(int id, UpdateTaskViewModel updateModel)
        {
            await GetAccessToken();
            var response = await _httpClient.PutAsJsonAsync($"/api/Task/edit/{id}", updateModel);
            return await response.Content.ReadAsStringAsync();

        }
        public async Task ValidateSessionAsync()
        {
            await GetAccessToken();
        }
    }
}
