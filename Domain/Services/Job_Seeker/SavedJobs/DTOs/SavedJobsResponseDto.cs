namespace Domain.Services.Job_Seeker.SavedJobs.DTOs
{
    public class SavedJobsResponseDto
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime SavedAt { get; set; }
    }
}
