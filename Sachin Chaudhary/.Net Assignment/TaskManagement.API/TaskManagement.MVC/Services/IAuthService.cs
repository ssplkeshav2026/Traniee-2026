using TaskManagement.MVC.ViewModels;

namespace TaskManagement.MVC.Interfaces
{
    public interface IAuthService
    {

        Task<AuthResponseViewModel?> Login(
            LoginViewModel model);


        Task<bool> Register(
            RegisterViewModel model);

    }
}