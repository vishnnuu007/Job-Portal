using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Jobs.DTOs;

namespace Domain.Services.Jobs.Interfaces
{
    public interface IJobService
    {
        Task<List<GetJobsDto>> GetAllJobsAsync1();
        Task<List<GetJobsDto>> SearchJobsAsync(string? keyword);
        public Task<JobDto> CreateJobAsync(CreateJobDto dto);
        public Task<JobDto> GetJobByIdAsync(Guid jobId);
        public Task<IEnumerable<JobDto>> GetAllJobsAsync();
        public Task<JobDto> UpdateJobAsync(Guid jobId, UpdateJobDto dto);
        public Task<bool> DeleteJobAsync(Guid jobId);
        Task<JobStatsDto> GetJobStatsAsync(Guid companyId);
    }
}
