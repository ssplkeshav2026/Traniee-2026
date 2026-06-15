using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystemAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
