using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Job
    {
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("CompanyMember")]
        public Guid CompanyMemberId { get; set; }
        public CompanyMember? CompanyMember { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public JobCategory Category { get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public JobStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
        public ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
    }
}
