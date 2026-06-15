using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Seeker.Applications.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Seeker.Applications
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly AppDbContext _context;

        public JobApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync(Guid jobSeekerId, Guid jobId)
        {
            return await _context.JobApplications
                .AnyAsync(x => x.JobSeekerId == jobSeekerId && x.JobId == jobId);
        }

        public async Task AddAsync(JobApplication jobApplication)
        {
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
        }

        public async Task<List<JobApplication>> GetByJobSeekerId(Guid jobSeekerId)
        {
            return await _context.JobApplications
                .Include(x => x.Job)
                .ThenInclude(j => j.Company)
                .Where(x => x.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }
    }
}
