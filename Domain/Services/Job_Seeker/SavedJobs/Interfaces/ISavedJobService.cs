using Domain.Models;
using Domain.Services.Job_Seeker.SavedJobs.DTOs;

namespace Domain.Services.Job_Seeker.SavedJobs.Interfaces
{
    public interface ISavedJobService
    {
        Task SavedJobAsync(Guid jobSeekerId, SavedJobDto dto);
        Task<List<SavedJobsResponseDto>> GetSavedJobsAsync(Guid jobSeekerId);
        Task RemoveSavedJobAsync(Guid jobSeekerId, Guid jobId);
    }
}
