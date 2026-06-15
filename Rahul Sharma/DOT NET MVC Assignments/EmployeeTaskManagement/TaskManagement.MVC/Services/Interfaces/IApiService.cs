

namespace TaskManagement.MVC.Services.Interfaces
{
    public interface IApiService
    {
        Task<TResponse?> GetAsync<TResponse>(string endpoint);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task<TResponse?> PatchAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task<bool> DeleteAsync(string endpoint);
    }
}