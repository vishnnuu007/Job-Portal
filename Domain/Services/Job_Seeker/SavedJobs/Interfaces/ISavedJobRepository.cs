using Domain.Models;

namespace Domain.Services.Job_Seeker.SavedJobs.Interfaces
{
    public interface ISavedJobRepository
    {
        Task<bool> ExistAsync(Guid jobSeekerId, Guid jobId);
        Task AddAsync(SavedJob savedJobs);
        Task<List<SavedJob>> GetByJobSeekerIdAsync(Guid jobSeekerId);
        Task DeleteAsync(Guid jobSeekerId, Guid jobId);
    }
}
