using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Services.Job_Seeker.Applications.DTOs;
using Domain.Services.Job_Seeker.Applications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Seeker.Applications
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repo;
        private readonly IMapper _mapper;

        public JobApplicationService(IJobApplicationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task ApplyJobAsync(Guid jobSeekerId, ApplyJobDto dto)
        {
           
            var exists = await _repo.ExistAsync(jobSeekerId, dto.JobId);

            if (exists)
                throw new InvalidOperationException("Already applied for this job");

            var application = _mapper.Map<JobApplication>(dto);

            application.Id = Guid.NewGuid();
            application.JobSeekerId = jobSeekerId;
            application.AppliedDate = DateTime.Now;
            application.Status = ApplicationStatus.Applied;

            await _repo.AddAsync(application);     
        }
   
        
        public async Task<List<MyApplicationDto>> GetMyApplicationsAsync(Guid jobSeekerId)
        {
            var applications = await _repo.GetByJobSeekerId(jobSeekerId);

            return _mapper.Map<List<MyApplicationDto>>(applications);
        }
    }
}
