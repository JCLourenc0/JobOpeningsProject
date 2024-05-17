using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsOpeningsProject.Entities.JobEntities
{
    public class JobRequest
    {
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public DateTime ClosingDate { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
    }
}