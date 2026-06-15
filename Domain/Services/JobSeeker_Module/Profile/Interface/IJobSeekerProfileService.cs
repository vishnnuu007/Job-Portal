using Domain.Services.JobSeeker_Module.Profile.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.Interface
{
        public interface IJobSeekerProfileService
        {
            Task<string> CreateAsync(Guid userId,CreateJobSeekerProfileDto dto);

            Task<JobSeekerProfileResponseDto> GetProfileAsync(Guid userId);

           Task<string> UpdateAsync(Guid userId, UpdateJobSeekerProfileDto dto);

            Task<string> DeleteAsync(Guid userId);



    }
    }
