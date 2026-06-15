using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemMVC.ViewModel
{
    public class EditTaskViewModel
    {
        
        public int Id { get; set; }

             
        public string Title { get; set; } = string.Empty;
       
        public string Description { get; set; } = string.Empty;

        
        public string AssignedToUserId { get; set; }

        
        public string Status { get; set; } = "Pending";

        
        public DateTime DueDate { get; set; }
    }
}
