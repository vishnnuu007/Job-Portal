using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        [ForeignKey("Job")]
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("JobSeeker")]
        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }

        [ForeignKey("Resume")]
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
        public DateTime AppliedDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
