using AutoMapper;
using Domain.Models;
using Domain.Services.JobSeeker_Module.Profile.DTO;
using Domain.Services.JobSeeker_Module.Profile.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.Service
{
    public class JobSeekerProfileService : IJobSeekerProfileService
    {
        private readonly IJobSeekerProfileRepository _repository;

        private readonly IMapper _mapper;

        public JobSeekerProfileService(IJobSeekerProfileRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> CreateAsync(Guid userId, CreateJobSeekerProfileDto dto)
        {
            var jobSeeker = await _repository.GetJobSeekerByAuthUserId(userId);

            if (jobSeeker == null)
                throw new Exception("JobSeeker not found");

            var profile = _mapper.Map<JobSeekerProfile>(dto);

            profile.Id = Guid.NewGuid();
            profile.JobSeekerId = jobSeeker.Id;

            // Fetch skills and qualifications by IDs
            profile.Skills = await _repository.GetSkillsByIds(dto.SkillIds);
            profile.Qualifications = await _repository.GetQualificationsByIds(dto.QualificationIds);

            await _repository.CreateAsync(profile);

            return "Profile Created Successfully";
        }

        public async Task<JobSeekerProfileResponseDto> GetProfileAsync(Guid userId)
        {
            var jobSeeker = await _repository
                .GetJobSeekerByAuthUserId(userId);

            if (jobSeeker == null)
            {
                throw new Exception("JobSeeker not found");
            }

            var profile = await _repository
                .GetProfileByJobSeekerId(jobSeeker.Id);

            if (profile == null)
            {
                throw new Exception("Profile not found");
            }
            return new JobSeekerProfileResponseDto
            {
                Id = profile.Id,
                ProfileName = profile.ProfileName,
                ProfileDescription = profile.ProfileDescription,
                Experience = profile.Experience,
                Skills = profile.Skills?.Select(s => s.Name).ToList(),
                Qualifications = profile.Qualifications?.Select(q => q.Name).ToList()
            };

        }

      public async Task<string> UpdateAsync(Guid userId, UpdateJobSeekerProfileDto dto)
        {
            var jobSeeker = await _repository.GetJobSeekerByAuthUserId(userId);

            if (jobSeeker == null)
                throw new Exception("JobSeeker not found");

            var profile = await _repository.GetProfileByJobSeekerId(jobSeeker.Id);

            if (profile == null)
                throw new Exception("Profile not found");

            profile.ProfileName = dto.ProfileName;
            profile.ProfileDescription = dto.ProfileDescription;
            profile.Experience = dto.Experience;

            // Replace collections with fresh entities
            profile.Skills = await _repository.GetSkillsByIds(dto.SkillIds);
            profile.Qualifications = await _repository.GetQualificationsByIds(dto.QualificationIds);

            await _repository.UpdateAsync(profile);

            return "Profile Updated Successfully";
        }

        public async Task<string> DeleteAsync(Guid userId)
        {
            // 1. Get JobSeeker
            var jobSeeker = await _repository.GetJobSeekerByAuthUserId(userId);

            if (jobSeeker == null)
                throw new Exception("JobSeeker not found");

            // 2. Get Profile
            var profile = await _repository.GetProfileByJobSeekerId(jobSeeker.Id);

            if (profile == null)
                throw new Exception("Profile not found");

            // 3. Delete Profile
            await _repository.DeleteAsync(profile);

            return "Profile deleted successfully";
        }

    }
}