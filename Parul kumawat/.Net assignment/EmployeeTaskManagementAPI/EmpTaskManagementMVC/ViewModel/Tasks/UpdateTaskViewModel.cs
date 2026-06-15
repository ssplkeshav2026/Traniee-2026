namespace EmpTaskManagementMVC.ViewModel.Tasks
{
    public class UpdateTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
