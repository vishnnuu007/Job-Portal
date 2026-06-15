namespace Domain.Services.Job_Seeker.Interviews.DTOs
{
    public class InterviewDto
    {
        public string JobTitle { get; set; } = null!;
        public DateTime InterviewDate { get; set; }
        public string Mode { get; set; } = null!;
        public string Status {  get; set; } = null!;
    }
}
