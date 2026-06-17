using EmployeeTaskManagementSystemAPI.Data;
using EmployeeTaskManagementSystemAPI.IRepository;
using EmployeeTaskManagementSystemAPI.Models;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IGenericRepository<TaskItem> Tasks { get; }
    public IGenericRepository<RefreshToken> RefreshTokens { get; }
    

    public UnitOfWork(AppDbContext context, IGenericRepository<TaskItem> employeeRepository, IGenericRepository<RefreshToken> GenericRepository)
    {
        _context = context;

        Tasks = employeeRepository;
        RefreshTokens = GenericRepository;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
