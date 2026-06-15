namespace EmployeeTaskManagementSystemMVC.ViewModels
{
    public class AuthResponseVM
    {
        public string AccessToken {  get; set;}
        public string RefreshToken {  get; set; }
        public int ExpiresIn {  get; set; }
    }
}
