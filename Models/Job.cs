using System;
using System.Collections.Generic;

namespace JobsOpeningsProject.Models;

public partial class Job
{
    public int Jobid { get; set; }

    public string Jobcode { get; set; } = null!;

    public string Jobtitle { get; set; } = null!;

    public string Jobdescription { get; set; } = null!;

    public DateTime? Posteddate { get; set; }

    public DateTime? Closingdate { get; set; }

    public int Locationid { get; set; }

    public int Departmentid { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
