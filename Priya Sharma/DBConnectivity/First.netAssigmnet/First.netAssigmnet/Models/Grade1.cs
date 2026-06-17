using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace First.netAssigmnet.Models;

public partial class Grade1
{
    [Required]

    public int? GradeId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }
}
