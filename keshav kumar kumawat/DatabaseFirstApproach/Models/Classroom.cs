using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApproach.Models;

public partial class Classroom
{
    public int ClassroomId { get; set; }

    //[DataType(DataType.Date)]
    public int? Year { get; set; }

    public int? GradeId { get; set; }

    public string? Section { get; set; }

    public bool? Status { get; set; }

    public string? Remarks { get; set; }

    public int? TeacherId { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
