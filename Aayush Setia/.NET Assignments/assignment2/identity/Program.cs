using identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<identityDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<identityUser, IdentityRole>()
    .AddEntityFrameworkStores<identityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";

    options.LogoutPath = "/Account/Logout";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

    options.SlidingExpiration = false;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles ={ "Admin","Manager","Member"};

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(
                new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<identityUser>>();

    string email = "Admin@gmail.com";
    string password = "Admin@123";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new identityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            IsActive = true
        };

        var result =
            await userManager.CreateAsync(
                user,
                password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(
                user,
                "Admin");
        }
    }
}

app.Run();