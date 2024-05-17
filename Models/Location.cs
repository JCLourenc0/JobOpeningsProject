using System;
using System.Collections.Generic;

namespace JobsOpeningsProject.Models;

public partial class Location
{
    public int Locationid { get; set; }

    public string Locationtitle { get; set; } = null!;

    public string Locationcity { get; set; } = null!;

    public string Locationstate { get; set; } = null!;

    public string Locationcountry { get; set; } = null!;

    public int Locationzip { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
