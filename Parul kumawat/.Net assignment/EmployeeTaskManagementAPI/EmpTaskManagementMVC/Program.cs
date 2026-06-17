using EmployeeTaskManagementAPI.Filters;
using EmpTaskManagementMVC.Filters;
using EmpTaskManagementMVC.IService;
using EmpTaskManagementMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<MvcValidationFilter>();
    options.Filters.Add<MvcGlobalException>();
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/MvcAuth/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });
builder.Services.AddHttpClient<IMvcAuthService, MvcAuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7121/");
});
builder.Services.AddHttpClient<IMvcTasksService, MvcTasksService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7121/");
});
builder.Services.AddHttpClient<IMvcUsersService, MvcUsersService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7121/");
});
builder.Services.AddScoped<MvcValidationFilter>();
builder.Services.AddScoped<MvcGlobalException>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MvcAuth}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
