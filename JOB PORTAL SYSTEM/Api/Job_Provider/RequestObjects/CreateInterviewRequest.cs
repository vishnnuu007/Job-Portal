using Domain.Enums;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider.RequestObjects
{
    public class CreateInterviewRequest
    {
        public Guid ApplicationId { get; set; }

        public DateTime InterviewDate { get; set; }

        public InterviewMode Mode { get; set; }

        public InterviewStatus Status { get; set; }
    }
}
