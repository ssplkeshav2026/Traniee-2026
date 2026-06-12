using TaskManagement.API.DTOs;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponseDto>> GetAllAsync();

        Task<TaskResponseDto> GetByIdAsync(int id);

        Task<TaskResponseDto> CreateAsync(
            CreateTaskDto dto,
            string assignedByUserId);

        Task<bool> UpdateAsync(
            int id,
            UpdateTaskDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
