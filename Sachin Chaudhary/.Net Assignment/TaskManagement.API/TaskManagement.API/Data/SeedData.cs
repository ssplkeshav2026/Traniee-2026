using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models;

namespace TaskManagement.API.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(
            IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var context =
                serviceProvider.GetRequiredService<ApplicationDbContext>();

            // ROLES
            string[] roles =
            {
                "Admin",
                "Manager",
                "Employee"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }

            // ADMIN
            var admin =
                await userManager.FindByEmailAsync("admin@test.com");

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@test.com",
                    UserName = "admin@test.com"
                };

                await userManager.CreateAsync(
                    admin,
                    "Admin@123");

                await userManager.AddToRoleAsync(
                    admin,
                    "Admin");
            }

            // MANAGER
            var manager =
                await userManager.FindByEmailAsync("manager@test.com");

            if (manager == null)
            {
                manager = new ApplicationUser
                {
                    FirstName = "Project",
                    LastName = "Manager",
                    Email = "manager@test.com",
                    UserName = "manager@test.com"
                };

                await userManager.CreateAsync(
                    manager,
                    "Manager@123");

                await userManager.AddToRoleAsync(
                    manager,
                    "Manager");
            }

            // EMPLOYEE 1
            var employee1 =
                await userManager.FindByEmailAsync("employee1@test.com");

            if (employee1 == null)
            {
                employee1 = new ApplicationUser
                {
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    Email = "employee1@test.com",
                    UserName = "employee1@test.com"
                };

                await userManager.CreateAsync(
                    employee1,
                    "Employee@123");

                await userManager.AddToRoleAsync(
                    employee1,
                    "Employee");
            }

            // EMPLOYEE 2
            var employee2 =
                await userManager.FindByEmailAsync("employee2@test.com");

            if (employee2 == null)
            {
                employee2 = new ApplicationUser
                {
                    FirstName = "Amit",
                    LastName = "Verma",
                    Email = "employee2@test.com",
                    UserName = "employee2@test.com"
                };

                await userManager.CreateAsync(
                    employee2,
                    "Employee@123");

                await userManager.AddToRoleAsync(
                    employee2,
                    "Employee");
            }

            await context.SaveChangesAsync();

            // SAMPLE TASKS
            if (!await context.Tasks.AnyAsync())
            {
                var employees =
                    await userManager.GetUsersInRoleAsync("Employee");

                var firstEmployee = employees.FirstOrDefault();
                var secondEmployee = employees.Skip(1).FirstOrDefault();

                if (firstEmployee != null && secondEmployee != null)
                {
                    var tasks = new List<TaskItem>
                    {
                        new TaskItem
                        {
                            Title = "Design Database",
                            Description = "Create database schema",
                            AssignedToUserId = firstEmployee.Id,
                            AssignedByUserId = manager!.Id,
                            Status = "Pending",
                            DueDate = DateTime.UtcNow.AddDays(7),
                            CreatedDate = DateTime.UtcNow
                        },
                        new TaskItem
                        {
                            Title = "Implement Login",
                            Description = "JWT Login API",
                            AssignedToUserId = secondEmployee.Id,
                            AssignedByUserId = manager.Id,
                            Status = "In Progress",
                            DueDate = DateTime.UtcNow.AddDays(5),
                            CreatedDate = DateTime.UtcNow
                        },
                        new TaskItem
                        {
                            Title = "Create Dashboard",
                            Description = "MVC Dashboard Page",
                            AssignedToUserId = firstEmployee.Id,
                            AssignedByUserId = admin!.Id,
                            Status = "Pending",
                            DueDate = DateTime.UtcNow.AddDays(10),
                            CreatedDate = DateTime.UtcNow
                        },
                        new TaskItem
                        {
                            Title = "API Testing",
                            Description = "Swagger Testing",
                            AssignedToUserId = secondEmployee.Id,
                            AssignedByUserId = admin.Id,
                            Status = "Completed",
                            DueDate = DateTime.UtcNow.AddDays(2),
                            CreatedDate = DateTime.UtcNow
                        },
                        new TaskItem
                        {
                            Title = "Bug Fixing",
                            Description = "Fix Authentication Issues",
                            AssignedToUserId = firstEmployee.Id,
                            AssignedByUserId = manager.Id,
                            Status = "Pending",
                            DueDate = DateTime.UtcNow.AddDays(3),
                            CreatedDate = DateTime.UtcNow
                        }
                    };

                    await context.Tasks.AddRangeAsync(tasks);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}