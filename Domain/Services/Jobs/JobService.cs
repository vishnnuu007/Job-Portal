using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Jobs.DTOs;
using Domain.Services.Jobs.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repo;
        private readonly IMapper _mapper;

        public JobService(IJobRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetJobsDto>> GetAllJobsAsync1()
        {
            var jobs = await _repo.GetAllAsync();

            return _mapper.Map<List<GetJobsDto>>(jobs);
        }

        public async Task<List<GetJobsDto>> SearchJobsAsync(string? keyword)
        {
            var jobs = await _repo.SearchAsync(keyword);

            return _mapper.Map<List<GetJobsDto>>(jobs);
        }
        public async Task<JobDto> CreateJobAsync(CreateJobDto dto)
        {
            try
            {
                var job = _mapper.Map<Job>(dto);
                job.Id = Guid.NewGuid();
                job.CreatedAt = DateTime.UtcNow;

                var created = await _repo.AddJobAsync(job);

                return _mapper.Map<JobDto>(created);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new ApplicationException("An error occurred while creating the job.", ex);
            }
        }

        public async Task<JobDto> GetJobByIdAsync(Guid jobId)
        {
            try
            {
                var job = await _repo.GetJobByIdAsync(jobId);
                if (job == null)
                {
                    return null;
                }
                return _mapper.Map<JobDto>(job);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new ApplicationException("An error occurred while retrieving the job.", ex);
            }
        }

        public async Task<IEnumerable<JobDto>> GetAllJobsAsync()
        {
            try
            {
                var jobs = await _repo.GetAllJobsAsync();
                return _mapper.Map<List<JobDto>>(jobs);

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new ApplicationException("An error occurred while retrieving jobs.", ex);
            }
        }

        public async Task<JobDto> UpdateJobAsync(Guid jobId, UpdateJobDto dto)
        {
            try
            {
                var job = await _repo.GetJobByIdAsync(jobId);
                if (job == null)
                {
                    throw new Exception("Job Not Found");
                }
                _mapper.Map(dto, job);

                var updated = await _repo.UpdateJobAsync(job);
                return _mapper.Map<JobDto>(updated);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the job.", ex);
            }
        }


        public async Task<bool> DeleteJobAsync(Guid jobId)
        {
            try
            {
                var job = await _repo.GetJobByIdAsync(jobId);
                if (job == null)
                {
                    throw new Exception("Job not found");
                }
                return await _repo.DeleteJobAsync(jobId);

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new ApplicationException("An error occurred while deleting the job.", ex);
            }
        }
        public async Task<JobStatsDto> GetJobStatsAsync(Guid companyId)
        {
            try
            {
                return new JobStatsDto
                {
                    TotalJobs = await _repo.GetTotalJobsAsync(companyId),
                    CreatedJobs = await _repo.GetCountByStatusAsync(companyId, JobStatus.Created),
                    PendingJobs = await _repo.GetCountByStatusAsync(companyId, JobStatus.Pending),
                    ActiveJobs = await _repo.GetCountByStatusAsync(companyId, JobStatus.Active),
                    ClosedJobs = await _repo.GetCountByStatusAsync(companyId, JobStatus.Closed),
                    VerifiedJobs = await _repo.GetCountByStatusAsync(companyId, JobStatus.Verified)
                };
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new ApplicationException("An error occurred while retrieving job statistics.", ex);
            }
        }
    }
}
    
