using System.ComponentModel.DataAnnotations;

namespace Domain.Services.Job_Seeker.SavedJobs.DTOs
{
    public class SavedJobDto
    {
        [Required]
        public Guid JobId { get; set; }
    }
}
