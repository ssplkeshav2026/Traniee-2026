using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.MVC.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title parameter is mandatory.")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Due target date threshold required.")]
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(1);

        // ✅ FIXED: Added specific configuration fields to hook user/employee allocations
        [Required(ErrorMessage = "An assignee worker ID must be specified.")]
        public string AssignedToUserId { get; set; } = string.Empty;
    }
}