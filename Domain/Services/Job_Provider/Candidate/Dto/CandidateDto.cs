using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Candidate.Dto
{
    public class CandidateDto
    {
        public Guid CandidateId { get; set; }

        public string CandidateName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProfileName { get; set; }

        public string ProfileDescription { get; set; }

        public string Experience { get; set; }
    }

}

