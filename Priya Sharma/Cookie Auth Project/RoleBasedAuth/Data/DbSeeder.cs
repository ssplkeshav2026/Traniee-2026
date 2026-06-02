using Microsoft.AspNetCore.Identity;
using RoleBasedAuth.Models.Domain;

namespace RoleBasedAuth.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            {
                "Admin",
                "User",
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

            // Admin Email
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin@123";

            var adminUser =
                await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    Name = "Main Admin",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Status = true,
                    EmailConfirmed = true
                };

                var result =
                    await userManager.CreateAsync(
                        admin,adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(
                        admin,
                        "Admin");
                }
            }
        }

    }
}
