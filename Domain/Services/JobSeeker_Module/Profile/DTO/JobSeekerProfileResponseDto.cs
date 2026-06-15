using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.DTO
{
    public class JobSeekerProfileResponseDto
    {
        public Guid Id { get; set; }

        public string ProfileName { get; set; }

        public string ProfileDescription { get; set; }

        public string Experience { get; set; }

        public List<string> Skills { get; set; }

        public List<string> Qualifications { get; set; }
    }
}
