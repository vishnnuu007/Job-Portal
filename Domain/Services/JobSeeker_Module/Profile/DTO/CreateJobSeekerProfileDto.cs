using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.DTO
{
    public class CreateJobSeekerProfileDto
    {
        public Guid JobSeekerId { get; set; }

        public string ProfileName { get; set; }

        public string ProfileDescription { get; set; }

        public string Experience { get; set; }

        public List<Guid>? SkillIds { get; set; }

        public List<Guid> QualificationIds { get; set; }

    }
}
