namespace JOB_PORTAL_SYSTEM.Api.ADMIN.RequestObjects
{
    public class JobStatsRequest
    {
        public int TotalJobs { get; set; }
        public int CreatedJobs { get; set; }
        public int PendingJobs { get; set; }
        public int ActiveJobs { get; set; }
        public int ClosedJobs { get; set; }
        public int VerifiedJobs { get; set; }
    }
}
