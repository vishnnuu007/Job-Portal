using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Job_Service.DTO
{
    public class CreateJobDto
    {
        public Guid CompanyId { get; set; }
        public Guid CompanyMemberId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }

        public Guid CategoryId { get; set; }
        public Guid LocationId { get; set; }
        public JobStatus Status { get; set; } 
    }
}
