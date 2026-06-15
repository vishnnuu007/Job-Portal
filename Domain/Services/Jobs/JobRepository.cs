using Domain.Data;
using Domain.Enums;
using Domain.Models;
using Domain.Services.Jobs.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Location)
                .Include(j => j.CompanyMember)
                .ToListAsync();
        }

        public async Task<List<Job>> SearchAsync(string? keyword)
        {
            var query = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Location)
                .Include(j => j.CompanyMember)
                .AsQueryable();



            if(!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(j => j.Title.Contains(keyword));
            }



            return await query.ToListAsync();
        }
        public async Task<Job> AddJobAsync(Job job)
        {
            try
            {
                var company = await _context.Companies.FindAsync(job.CompanyId);
                if (company == null)
                {
                    throw new Exception("Company not found");
                }
                var category = await _context.JobCategories.FindAsync(job.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }
                var location = await _context.Locations.FindAsync(job.LocationId);
                if (location == null)
                {
                    throw new Exception("Location not found");
                }

                var member = await _context.CompanyMembers.FindAsync(job.CompanyMemberId);
                if (member == null || member.CompanyId != job.CompanyId)
                {
                    throw new Exception("Company member not found or does not belong to this company");
                }



                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
                return job;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding job: {ex.Message}");
            }
        }

        public async Task<Job?> GetJobByIdAsync(Guid jobId)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(jobId);
                if (job == null)
                {
                    throw new Exception("Job not found");
                }

                return await _context.Jobs
                    .Include(j => j.Company)
                    .Include(j => j.Category)
                    .Include(j => j.Location)
                    .Include(j => j.CompanyMember)
                    .FirstOrDefaultAsync(j => j.Id == jobId);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving job: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            try
            {
                if (!await _context.Jobs.AnyAsync())
                {
                    return new List<Job>();
                }
                return await _context.Jobs
                    .Include(j => j.Company)
                    .Include(j => j.Category)
                    .Include(j => j.Location)
                    .Include(j => j.CompanyMember)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving jobs: {ex.Message}");
            }
        }

        public async Task<Job> UpdateJobAsync(Job job)
        {
            try
            {
                var existingJob = await _context.Jobs.FindAsync(job.Id);
                if (existingJob == null)
                {
                    throw new Exception("Job not found");
                }
                var company = await _context.Companies.FindAsync(job.CompanyId);
                if (company == null)
                {
                    throw new Exception("Company not found");
                }
                var category = await _context.JobCategories.FindAsync(job.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }
                var location = await _context.Locations.FindAsync(job.LocationId);
                if (location == null)
                {
                    throw new Exception("Location not found");
                }
                _context.Jobs.Update(job);
                await _context.SaveChangesAsync();
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating job: {ex.Message}");
            }
        }

        public async Task<bool> DeleteJobAsync(Guid jobId)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(jobId);
                if (job == null)
                {
                    throw new Exception("Job not found");
                }
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting job: {ex.Message}");
            }
        }

        public async Task<int> GetTotalJobsAsync(Guid companyId)
        {
            try
            {
                return await _context.Jobs
                    .Where(j => j.CompanyId == companyId)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error counting jobs: {ex.Message}");
            }
        }

        public async Task<int> GetCountByStatusAsync(Guid companyId, JobStatus status)
        {
            try
            {
                return await _context.Jobs
                    .Where(j => j.CompanyId == companyId && j.Status == status)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error counting jobs by status: {ex.Message}");
            }
        }
    }

}

