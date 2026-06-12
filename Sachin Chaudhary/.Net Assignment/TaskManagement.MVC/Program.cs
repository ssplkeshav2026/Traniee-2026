using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using TaskManagement.MVC.Filters;
using TaskManagement.MVC.Handlers;
using TaskManagement.MVC.Helpers;
using TaskManagement.MVC.Interfaces;
using TaskManagement.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Register base framework layout views
builder.Services.AddControllersWithViews(options =>
{
    // 1. Automatic Type Safe ModelState Validation Filter
    options.Filters.Add<ValidationFilter>();

    // 2. Performance Tracking Metric Logger Filter 
    options.Filters.Add<LoggingFilter>();

    // 3. System Recovery Global Exception Handler Break Filter
    options.Filters.Add<GlobalExceptionFilter>();
});

// HTTP context proxy dependency used for cookie writes
builder.Services.AddHttpContextAccessor();

// System application interface implementation bindings
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Register structural pipeline message interceptor handler
builder.Services.AddTransient<TokenRefreshHandler>();
builder.Services.AddTransient<AuthenticatingHandler>();
// 1. Register HttpClient with your backend API's actual port address
builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    // ⚠️ Replace 7123 with whatever port number your actual Backend API project runs on!
    client.BaseAddress = new Uri("https://localhost:7244/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
// Explicitly register ApiService with its delegating refresh handler
builder.Services.AddHttpClient<IApiService, ApiService>()
    .AddHttpMessageHandler<TokenRefreshHandler>();

// Setup authentication engine schemas with explicit redirection configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";         // Sahi Login Path explicit set karein
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "TaskManagementAuthCookie";
        options.Cookie.HttpOnly = true;               // Security enforce karein
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication middleware must execute prior to authorization checks
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();