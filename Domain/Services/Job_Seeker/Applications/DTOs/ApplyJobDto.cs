using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Job_Seeker.Applications.DTOs
{
    public class ApplyJobDto
    {
        [Required]
        public Guid JobId { get; set; }
        [Required]
        public Guid ResumeId { get; set; }
    }
}
