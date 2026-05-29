using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class CourcesViewModel
    {

        public int CourceId { get; set; }

            [Required]
            public string? Name { get; set; }
            [Required]
            public string? Description { get; set; }
            [Required]
            public int? GradeId { get; set; }
           
  
        

    }
}
