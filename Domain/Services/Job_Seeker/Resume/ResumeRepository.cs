using Domain.Data;
using Domain.Services.Job_Seeker.Resume.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Job_Seeker.Resume
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _context;

        public ResumeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Resume?> GetByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.Resumes
                .FirstOrDefaultAsync(x => x.JobSeekerId == jobSeekerId);
        }

        public async Task AddAsync(Domain.Models.Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Models.Resume resume)
        {
            _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();
        }
    }
}
