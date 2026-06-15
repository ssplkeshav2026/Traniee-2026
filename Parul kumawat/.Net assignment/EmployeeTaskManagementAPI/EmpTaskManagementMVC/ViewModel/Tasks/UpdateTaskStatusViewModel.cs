using EmployeeTaskManagementAPI.Enum;

namespace EmpTaskManagementMVC.ViewModel.Tasks
{
    public class UpdateTaskStatusViewModel
    {
        public int Id { get; set; }
        public TasksStatus Status { get; set; }

    }
}
