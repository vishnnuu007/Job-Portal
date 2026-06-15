using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Seeker.Interviews.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Job_Seeker.Interviews
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext _context;

        public InterviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Interview>> GetByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.Interviews
                .Include(i => i.Application)
                .ThenInclude(a => a.Job)
                .Where(i => i.Application.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }
    }
}
