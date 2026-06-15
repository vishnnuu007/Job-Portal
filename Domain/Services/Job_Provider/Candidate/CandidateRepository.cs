using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Provider.Candidate.Dto;
using Domain.Services.Job_Provider.Candidate.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Candidate
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        


        public async Task<List<JobSeeker>> FilterCandidatesAsync(Guid skillId)

        {
            var candidates = await _context.JobSeekers
                .Include(x => x.Profile)
                    .ThenInclude(p => p.Skills) // include skills
                .Where(x =>
                    x.Profile != null &&
                    x.Profile.Skills.Any(s => s.Id == skillId)) // check if skill exists
                .ToListAsync();

            return candidates;
        }

    }
}
