using System.Security.Claims;
using TaskManagement.API.DTOs.Tasks;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponseDto>> GetAllTasksAsync(ClaimsPrincipal user);
        Task<TaskResponseDto> GetTaskByIdAsync(int id, ClaimsPrincipal user);
        Task<TaskResponseDto> CreateTaskAsync(CreateTaskRequestDto request, ClaimsPrincipal user);
        Task<TaskResponseDto> UpdateTaskAsync(int id, UpdateTaskRequestDto request, ClaimsPrincipal user);
        Task<TaskResponseDto> UpdateOwnTaskStatusAsync(int id, UpdateTaskStatusDto request, ClaimsPrincipal user);
        Task DeleteTaskAsync(int id, ClaimsPrincipal user);
    }
}