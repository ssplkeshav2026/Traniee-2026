using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManagementSystemApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public string? AssignedToUserId { get; set; }
        public string? AssignedByUserId { get; set; }
        public TaskitemStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("AssignedToUserId")]
        public ApplicationUser? AssignedTo { get; set; }

        [ForeignKey("AssignedByUserId")]
        public ApplicationUser? AssignedBy { get; set; }
    }
}
