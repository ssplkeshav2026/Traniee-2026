using Newtonsoft.Json;
using System;

namespace TaskManagement.MVC.ViewModels
{
    public class CreateTaskViewModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        public DateTime? DueDate { get; set; }

  
        [JsonProperty("assignedToUserId")]
        public string AssignedTo { get; set; }
    }
}