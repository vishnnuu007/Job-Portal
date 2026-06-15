using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewCompanyApplications.Dto
{
    public class CompanyApplicationDto
    {
        public Guid ApplicationId { get; set; }

        public string CandidateName { get; set; }

        public string JobTitle { get; set; }

        public DateTime AppliedAt { get; set; }

        public string Status { get; set; }
    }
}
