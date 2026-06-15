using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.Interface
{
    public interface IJobSeekerProfileRepository
    {
        Task<JobSeekerProfile> CreateAsync(JobSeekerProfile profile);
        Task<JobSeeker> GetJobSeekerByAuthUserId(Guid authUserId);

        Task<JobSeekerProfile?> GetProfileByJobSeekerId(Guid jobSeekerId);

        Task<JobSeekerProfile> UpdateAsync(JobSeekerProfile profile);

        Task<List<Skill>> GetSkillsByIds(List<Guid> ids);

        Task<List<Qualification>> GetQualificationsByIds(List<Guid> ids);

        Task DeleteAsync(JobSeekerProfile profile);
    }
}
