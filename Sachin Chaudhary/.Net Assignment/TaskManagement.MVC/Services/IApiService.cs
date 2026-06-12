using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManagement.MVC.Interfaces
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string url); // Now returns HttpResponseMessage instead of bool!
    }
}