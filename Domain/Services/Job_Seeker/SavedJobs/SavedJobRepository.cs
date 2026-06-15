using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Seeker.SavedJobs.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Job_Seeker.SavedJobs
{
    public class SavedJobRepository : ISavedJobRepository
    {
        private readonly AppDbContext _context;

        public SavedJobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync(Guid jobSeekerId, Guid jobId)
        {
            return await _context.SavedJobs
                .AnyAsync(x => x.JobSeekerId == jobSeekerId && x.JobId == jobId);
        }

        public async Task AddAsync(SavedJob savedJobs)
        {
            await _context.SavedJobs .AddAsync(savedJobs);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SavedJob>> GetByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.SavedJobs
                .Include(x => x.Job)
                .ThenInclude(j => j.Company)
                .Include(x => x.Job.Location)
                .Where(x => x.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }

        public async Task DeleteAsync(Guid jobSeekerId, Guid jobId)
        {
            var entity = await _context.SavedJobs
                .FirstOrDefaultAsync(x => x.JobSeekerId == jobSeekerId && x.JobId ==jobId);

            if (entity != null)
            {
                _context.SavedJobs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
