using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerSkills
    {
        public Guid Id { get; set; }

        [ForeignKey("JobSeeker")]
        public Guid JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }

        [ForeignKey("Skill")]
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
