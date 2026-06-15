using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerQualification
    {
        public Guid Id { get; set; }
        [ForeignKey("JobSeeker")]
        public Guid JobSeekerId { get; set; } // Foreign key to JobSeeker
        public JobSeeker JobSeeker { get; set; } // Navigation property to JobSeeker

        [ForeignKey("Qualification")]
        public Guid QualificationId { get; set; } // Foreign key to Qualification
        public Qualification Qualification { get; set; } // Navigation property to Qualification
        public string University { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
    }
}
