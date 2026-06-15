namespace Domain.Services.Job_Seeker.Applications.DTOs
{
    public class MyApplicationDto
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string CompanyName {  get; set; } = null!;
        public string Status {  get; set; } = null!;
        public DateTime AppliedDate { get; set; }
    }
}
