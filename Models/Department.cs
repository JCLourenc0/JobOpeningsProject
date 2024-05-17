using System;
using System.Collections.Generic;

namespace JobsOpeningsProject.Models;

public partial class Department
{
    public int Departmentid { get; set; }

    public string Departmenttitle { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
