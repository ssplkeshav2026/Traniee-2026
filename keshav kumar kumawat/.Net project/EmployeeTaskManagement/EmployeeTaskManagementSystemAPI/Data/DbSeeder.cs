using EmployeeTaskManagementSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeTaskManagementSystemAPI.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<AppDbContext>();

            string[] roles =
            {
                "Admin","Manager","Employee"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = await CreateUser(
                userManager,
                "admin12@test.com",                                //Email
                "Admin@123",                                     //Password
                "Admin",                                         //Role
                "Admin",                                         //Firstname
                "User"                                           //Lastname
            );

            var manager = await CreateUser(
                userManager,
                "manager@test.com",
                "Manager@123",
                "Manager",
                "Manager",
                "User"
            );

            var emp1 = await CreateUser(
                userManager,
                "employee1@test.com",
                "Employee@123",
                "Employee",
                "Employee",
                "One"
            );

            var emp2 = await CreateUser(
                userManager,
                "employee2@test.com", 
                "Employee@123",
                "Employee",
                "Employee",
                "Two"
            );



            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new TaskItem
                    {
                        Title = "Create Report",
                        Description = "Create monthly report",
                        AssignedByUserId = manager.Id,
                        AssignedToUserId = emp1.Id,
                        Status = "Pending",
                        DueDate = DateTime.Now.AddDays(5)
                    },
                    new TaskItem
                    {
                        Title = "Update Website",
                        Description = "Update home page content",
                        AssignedByUserId = manager.Id,
                        AssignedToUserId = emp2.Id,
                        Status = "In Progress",
                        DueDate = DateTime.Now.AddDays(3)
                    },
                    new TaskItem
                    {
                        Title = "Database Backup",
                        Description = "Take SQL Server backup",
                        AssignedByUserId = admin.Id,
                        AssignedToUserId = emp1.Id,
                        Status = "Pending",
                        DueDate = DateTime.Now.AddDays(2)
                    },
                    new TaskItem
                    {
                        Title = "Bug Fixing",
                        Description = "Fix login page bug",
                        AssignedByUserId = manager.Id,
                        AssignedToUserId = emp2.Id,
                        Status = "Completed",
                        DueDate = DateTime.Now.AddDays(4)
                    },
                    new TaskItem
                    {
                        Title = "API Testing",
                        Description = "Test protected APIs",
                        AssignedByUserId = admin.Id,
                        AssignedToUserId = emp1.Id,
                        Status = "Pending",
                        DueDate = DateTime.Now.AddDays(6)
                    }
                );

                await context.SaveChangesAsync();
            }
        }

        private static async Task<ApplicationUser> CreateUser(
            UserManager<ApplicationUser> userManager,
            string email,
            string password,
            string role,
            string firstName,
            string lastName)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Firstname = firstName,
                    Lastname = lastName
                };

                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, role);
            }

            return user;
        }
    }
}
