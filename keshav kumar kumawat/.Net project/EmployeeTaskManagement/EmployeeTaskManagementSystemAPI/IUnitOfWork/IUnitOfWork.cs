using EmployeeTaskManagementSystemAPI.IRepository;
using EmployeeTaskManagementSystemAPI.Models;

public interface IUnitOfWork
{
    IGenericRepository<TaskItem> Tasks { get; }
    IGenericRepository<RefreshToken> RefreshTokens { get; }

    Task<int> SaveAsync();
}