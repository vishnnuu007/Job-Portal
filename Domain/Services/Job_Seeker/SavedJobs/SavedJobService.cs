using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Seeker.SavedJobs.DTOs;
using Domain.Services.Job_Seeker.SavedJobs.Interfaces;

namespace Domain.Services.Job_Seeker.SavedJobs
{
    public class SavedJobService : ISavedJobService
    {
        private readonly ISavedJobRepository _repo;
        private readonly IMapper _mapper;

        public SavedJobService(ISavedJobRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task SavedJobAsync(Guid jobSeekerId, SavedJobDto dto)
        {
            var exist = await _repo.ExistAsync(jobSeekerId, dto.JobId);

            if (exist)
                throw new InvalidOperationException("Job already saved");

            var savedJob = new SavedJob
            {
                Id = Guid.NewGuid(),
                JobSeekerId = jobSeekerId,
                JobId = dto.JobId
            };

            await _repo.AddAsync(savedJob);
        }

        public async Task<List<SavedJobsResponseDto>> GetSavedJobsAsync(Guid jobSeekerId)
        {
            var data = await _repo.GetByJobSeekerIdAsync(jobSeekerId);

            return _mapper.Map<List<SavedJobsResponseDto>>(data);
        }

        public async Task RemoveSavedJobAsync(Guid jobSeekerId, Guid jobId)
        {
            await _repo.DeleteAsync(jobSeekerId, jobId);

        }
    }
}
