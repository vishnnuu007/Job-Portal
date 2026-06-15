using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Job_Service.DTO
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }

        public JobStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public string PostedBy { get; set; } // Company member name
        public CompanyRole Role { get; set; }
    }
}
