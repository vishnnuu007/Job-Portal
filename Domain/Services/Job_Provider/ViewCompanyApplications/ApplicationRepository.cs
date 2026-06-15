using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Provider.ViewCompanyApplications.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewCompanyApplications
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobApplication>> GetApplicationsByCompanyAsync(Guid companyId)
        {
            return await _context.JobApplications
                .Include(x => x.Job)
                .Include(x => x.JobSeeker)
                .Include(x => x.Resume)
                .Include(x => x.Interviews)
                .Where(x => x.Job.CompanyId == companyId)
                .ToListAsync();
        }

    }
}
