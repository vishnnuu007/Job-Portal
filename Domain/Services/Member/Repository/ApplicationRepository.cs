using Domain.Data;
using Domain.Models;
using Domain.Services.Member.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JobApplication> GetByIdAsync(Guid id)
        {
            return await _context.JobApplications.FindAsync(id);
        }

        public async Task<JobApplication> UpdateAsync(JobApplication application)
        {
            _context.JobApplications.Update(application);

            await _context.SaveChangesAsync();

            return application;
        }
    }
}