using Domain.Enums;
using Domain.Models;

namespace Domain.Services.Jobs.Interfaces
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync();
        Task<List<Job>> SearchAsync(string? keyword);
        Task<Job> AddJobAsync(Job job);
        Task<Job?> GetJobByIdAsync(Guid jobId);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(Guid jobId);
        Task<int> GetTotalJobsAsync(Guid companyId);
        Task<int> GetCountByStatusAsync(Guid companyId, JobStatus status);
    }
}
