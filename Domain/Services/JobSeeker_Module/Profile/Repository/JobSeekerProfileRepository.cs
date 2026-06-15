using Domain.Data;
using Domain.Models;
using Domain.Services.JobSeeker_Module.Profile.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker_Module.Profile.Repository
{
    public class JobSeekerProfileRepository : IJobSeekerProfileRepository
    {
        private readonly AppDbContext _context;

        public JobSeekerProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<JobSeekerProfile> CreateAsync(JobSeekerProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

           await _context.JobSeekerProfiles.AddAsync(profile);
           await _context.SaveChangesAsync();
            return profile;
        }
        public async Task<JobSeeker?> GetJobSeekerByAuthUserId(Guid authUserId)
        {
            return await _context.JobSeekers .FirstOrDefaultAsync(x => x.UserId == authUserId);
        }
        public async Task<JobSeekerProfile> GetProfileByJobSeekerId(Guid jobSeekerId)
        {
            return await _context.JobSeekerProfiles
                .Include(x => x.Skills)
                .Include(x => x.Qualifications)
                .FirstOrDefaultAsync(x => x.JobSeekerId == jobSeekerId);
        }
        public async Task<JobSeekerProfile> UpdateAsync(JobSeekerProfile profile)
        {
            _context.JobSeekerProfiles.Update(profile);

            await _context.SaveChangesAsync();

            return profile;
        }
        public async Task<List<Skill>> GetSkillsByIds(List<Guid> ids)
        {
            return await _context.Skills .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

       
        public async Task<List<Qualification>> GetQualificationsByIds(List<Guid> ids)
        {
            return await _context.Qualifications.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task DeleteAsync(JobSeekerProfile profile)
        {
            _context.JobSeekerProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}
