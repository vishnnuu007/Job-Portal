using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewJobs.Dto
{
    public class ViewCompanyJobDto
    {
        public Guid JobId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string CategoryName { get; set; }

        public string LocationName { get; set; }

        public JobStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
