using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            string[] roles = { "Admin", "Manager", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = await CreateUserIfNotExistsAsync(
                userManager,
                "admin@task.com",
                "System",
                "Admin",
                "Admin@123",
                "Admin");

            var manager = await CreateUserIfNotExistsAsync(
                userManager,
                "manager@task.com",
                "Project",
                "Manager",
                "Manager@123",
                "Manager");

            var employee1 = await CreateUserIfNotExistsAsync(
                userManager,
                "employee1@task.com",
                "Rahul",
                "Sharma",
                "Employee@123",
                "Employee");

            var employee2 = await CreateUserIfNotExistsAsync(
                userManager,
                "employee2@task.com",
                "Amit",
                "Verma",
                "Employee@123",
                "Employee");

            await SeedTasksAsync(context, manager.Id, employee1.Id, employee2.Id);
        }

        private static async Task<ApplicationUser> CreateUserIfNotExistsAsync(
            UserManager<ApplicationUser> userManager,
            string email,
            string firstName,
            string lastName,
            string password,
            string role)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            return user;
        }

        private static async Task SeedTasksAsync(
            ApplicationDbContext context,
            string managerId,
            string employee1Id,
            string employee2Id)
        {
            if (await context.EmployeeTasks.AnyAsync())
            {
                return;
            }

            var tasks = new List<EmployeeTask>
            {
                new EmployeeTask
                {
                    Title = "Create Login UI",
                    Description = "Design and implement login page for MVC application.",
                    AssignedByUserId = managerId,
                    AssignedToUserId = employee1Id,
                    Status = TaskStatusType.Pending,
                    DueDate = DateTime.UtcNow.AddDays(3),
                    CreatedDate = DateTime.UtcNow
                },
                new EmployeeTask
                {
                    Title = "Integrate JWT Authentication",
                    Description = "Consume login API and store access token in MVC application.",
                    AssignedByUserId = managerId,
                    AssignedToUserId = employee1Id,
                    Status = TaskStatusType.InProgress,
                    DueDate = DateTime.UtcNow.AddDays(5),
                    CreatedDate = DateTime.UtcNow
                },
                new EmployeeTask
                {
                    Title = "Create Task List Page",
                    Description = "Display all tasks using API response.",
                    AssignedByUserId = managerId,
                    AssignedToUserId = employee2Id,
                    Status = TaskStatusType.Pending,
                    DueDate = DateTime.UtcNow.AddDays(4),
                    CreatedDate = DateTime.UtcNow
                },
                new EmployeeTask
                {
                    Title = "Add jQuery AJAX Create Task",
                    Description = "Create task from MVC using secured AJAX request.",
                    AssignedByUserId = managerId,
                    AssignedToUserId = employee2Id,
                    Status = TaskStatusType.Pending,
                    DueDate = DateTime.UtcNow.AddDays(6),
                    CreatedDate = DateTime.UtcNow
                },
                new EmployeeTask
                {
                    Title = "Prepare Project Documentation",
                    Description = "Write project overview, API endpoints, and testing steps.",
                    AssignedByUserId = managerId,
                    AssignedToUserId = employee1Id,
                    Status = TaskStatusType.Completed,
                    DueDate = DateTime.UtcNow.AddDays(7),
                    CreatedDate = DateTime.UtcNow
                }
            };

            await context.EmployeeTasks.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
        }
    }
}