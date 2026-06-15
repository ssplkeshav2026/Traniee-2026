namespace TaskManagement.API.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string AssignedToUserId { get; set; }

        public DateTime DueDate { get; set; }
    }
}