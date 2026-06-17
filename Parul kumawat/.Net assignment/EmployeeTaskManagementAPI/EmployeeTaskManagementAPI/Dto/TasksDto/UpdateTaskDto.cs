using EmployeeTaskManagementAPI.Enum;

namespace EmployeeTaskManagementAPI.Dto.TasksDto
{
    public class UpdateTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; }= string.Empty;

        public DateTime DueDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
