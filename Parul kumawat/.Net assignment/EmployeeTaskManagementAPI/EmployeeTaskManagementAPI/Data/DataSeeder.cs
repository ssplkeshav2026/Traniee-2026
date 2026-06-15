using EmployeeTaskManagementAPI.Enum;
using EmployeeTaskManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementAPI.Data
{
    public class DataSeeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<AppDbContext>();


            string[] roles = { "Admin", "Employee", "Manager" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = await userManager.FindByEmailAsync("admin@gmail.com");

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    FirstName = "Admin",
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };


                var result = await userManager.CreateAsync(admin, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            var manager = await userManager.FindByEmailAsync("manager@gmail.com");

            if (manager == null)
            {
                manager = new ApplicationUser
                {
                    FirstName = "Manager",
                    UserName = "manager",
                    Email = "manager@gmail.com"
                };

                var result1 = await userManager.CreateAsync(manager, "Manager@123");
                if (result1.Succeeded)
                {
                    await userManager.AddToRoleAsync(manager, "Manager");
                }
            }

            var emp1 = await userManager.FindByEmailAsync("emp1@gmail.com");
            if (emp1 == null)
            {
                emp1 = new ApplicationUser
                {
                    FirstName = "Employee1",
                    UserName = "emp1",
                    Email = "emp1@gmail.com"
                };

                var res = await userManager.CreateAsync(emp1, "Emp@123");
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(emp1, "Employee");
                }
            }


            var emp2 = await userManager.FindByEmailAsync("emp2@gmail.com");
            if (emp2 == null)
            {
                emp2 = new ApplicationUser
                {
                    FirstName = "Employee2",
                    UserName = "emp2",
                    Email = "emp2@gmail.com"
                };

                var res = await userManager.CreateAsync(emp2, "Emp@123");
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(emp2, "Employee");
                }
            }
            await context.SaveChangesAsync();



            if (!await context.Tasks.AnyAsync())
            {
                var tasks = new List<Tasks>
                {
                    new Tasks
                    {
                        Title = "Setup Project Structure",
                        Description = "Initialize API structure and layers",
                        Status = TasksStatus.Pending.ToString(),
                        AssignedToUserId = emp1.Id
                    },
                    new Tasks
                    {
                        Title = "Design Database Schema",
                        Description = "Create tables for users and tasks",
                        Status = TasksStatus.InProgress.ToString(),
                        AssignedToUserId = emp2.Id
                    },
                    new Tasks
                    {
                        Title = "Implement Authentication",
                        Description = "JWT authentication setup",
                        Status = TasksStatus.Pending.ToString(),
                        AssignedToUserId = emp1.Id
                    },
                    new Tasks
                    {
                        Title = "Create Task API",
                        Description = "CRUD operations for tasks",
                        Status = TasksStatus.Pending.ToString(),
                        AssignedToUserId = emp2.Id
                    },
                    new Tasks
                    {
                        Title = "Write Unit Tests",
                        Description = "Test service layer logic",
                        Status = TasksStatus.Pending.ToString(),
                        AssignedToUserId = emp1.Id
                    }
                };

                await context.Tasks.AddRangeAsync(tasks);
                await context.SaveChangesAsync();
            }
        }

    }
    }


