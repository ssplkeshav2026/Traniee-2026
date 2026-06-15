namespace EmpTaskManagementMVC.ViewModel
{
    public class LoginTokenResponseViewModel
    {
        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; }= string.Empty;

        public int ExpiresIn { get; set; }

    }
}
