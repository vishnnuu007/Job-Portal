using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Interviews.Dto
{
    public class UpdateInterviewDto
    {
        public Guid Id { get; set; }
        public DateTime InterviewDate { get; set; }

        public InterviewMode Mode { get; set; }

        public InterviewStatus Status { get; set; }
    }
}
