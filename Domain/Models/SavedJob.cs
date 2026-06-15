using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SavedJob
    {
        public Guid Id { get; set; }
        [ForeignKey("JobSeeker")]
        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }

        [ForeignKey("Job")]
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public DateTime SavedAt { get; set; }

    }
}
