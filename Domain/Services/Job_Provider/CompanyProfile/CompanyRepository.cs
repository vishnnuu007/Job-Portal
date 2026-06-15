using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Provider.CompanyProfile.Interface;
using Microsoft.EntityFrameworkCore;


namespace Domain.Services.Job_Provider.CompanyProfile
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext context;
        public CompanyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Company> AddAsync(Company company)
        {
            try
            {
                var provider = await context.JobProviders.FindAsync(company.ProviderId);
                if (provider == null)
                {
                    throw new Exception("User not found");
                }
                var industry = await context.Industries.FindAsync(company.IndustryId);
                if (industry == null)
                {
                    throw new Exception("Industry not found");
                }
                var location = await context.Locations.FindAsync(company.LocationId);
                if (location == null)
                {
                    throw new Exception("Location not found");
                }
                context.Companies.Add(company);
                await context.SaveChangesAsync();
                return company;

            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error adding company: {ex.Message}");
                throw; 
            }
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            try
            {
                var company = await context.Companies.FindAsync(id);
                if (company == null)
                {
                    return null;
                }
                return await context.Companies
                    .Include(c => c.Industry)
                    .Include(c => c.Location)
                    .FirstOrDefaultAsync(c => c.Id == id);

            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error retrieving company: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }

        public async Task<IEnumerable<Company>> GetAllByUserIdAsync(Guid companyId)
        {
            try
            {
                return await context.Companies
                    .Where(c => c.Id == companyId)
                    .Include(c => c.Industry)
                    .Include(c => c.Location)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Company?> UpdateAsync(Guid CompanyId, Company company)
        {
            try
            {
                var existingCompany = await context.Companies.FindAsync(CompanyId);

                if (existingCompany == null)
                {
                    return null;
                }

                existingCompany.CompanyName = company.CompanyName;
                existingCompany.Description = company.Description;
                existingCompany.IndustryId = company.IndustryId;
                existingCompany.LocationId = company.LocationId;

                await context.SaveChangesAsync();
                return existingCompany;

            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error updating company: {ex.Message}");
                throw; 
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var company = await context.Companies.FindAsync(id);
                if (company == null)
                {
                    return false;
                }

                context.Companies.Remove(company);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<JobProvider?> GetByUserIdAsync(Guid userId)
        {
            return await context.JobProviders
                .FirstOrDefaultAsync(jp => jp.UserId == userId);
        }

        public async Task UpdateAsync(JobProvider jobProvider)
        {
            context.JobProviders.Update(jobProvider);
            await context.SaveChangesAsync();
        }


        //public async Task<List<Location>> GetLocationsByIdAsync(List<Guid> locationIds)
        //{
        //    return await context.Locations
        //        .Where(loc => locationIds.Contains(loc.Id))
        //        .ToListAsync();
        //}

        //public async Task<List<Industry>> GetAllIndustriesByIdAsync(List<Guid> industryIds)
        //{
        //    return await context.Industries
        //        .Where(ind => industryIds.Contains(ind.Id))
        //        .ToListAsync();

        //}
    }
}
