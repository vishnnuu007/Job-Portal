using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Jobs.DTOs
{
    public class JobStatsDto
    {
        public int TotalJobs { get; set; }
        public int CreatedJobs { get; set; }
        public int PendingJobs { get; set; }
        public int ActiveJobs { get; set; }
        public int ClosedJobs { get; set; }
        public int VerifiedJobs { get; set; }
    }
}
