using EmployeeTaskManagementSystemMVC.Filters;
using EmployeeTaskManagementSystemMVC.IServices;
using EmployeeTaskManagementSystemMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("TaskApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7085/");
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();