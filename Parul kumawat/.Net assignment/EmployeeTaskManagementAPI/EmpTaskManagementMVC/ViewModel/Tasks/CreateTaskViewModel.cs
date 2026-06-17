using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpTaskManagementMVC.ViewModel.Tasks
{
    public class CreateTaskViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string AssignedToUserId { get; set; } = string.Empty;



        public DateTime DueDate { get; set; }
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();

    }
}
