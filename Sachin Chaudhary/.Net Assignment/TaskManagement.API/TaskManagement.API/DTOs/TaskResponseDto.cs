namespace TaskManagement.API.DTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AssignedToUserId { get; set; }

        public string AssignedByUserId { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}