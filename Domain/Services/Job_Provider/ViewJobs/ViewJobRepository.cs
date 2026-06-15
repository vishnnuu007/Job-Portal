using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Provider.ViewJobs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewJobs
{
    public class ViewJobRepository:IViewJobRepository
    {
        private readonly AppDbContext _context;

        public ViewJobRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Job>> ViewJobsByCompanyIdAsync(Guid companyId)
        {
            return await _context.Jobs.Include (x=> x.Category).Include (x=>x.Location).Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
