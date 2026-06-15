using Domain.Data;
using Domain.Models;
using Domain.Services.Admin.CompanyVerification.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Admin.CompanyVerification
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetCompanyByIdAsync(Guid compId)
        {
            try
            {
                return await _context.Companies.FirstOrDefaultAsync(c => c.Id == compId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving company with ID {compId}: {ex.Message}", ex);
            }
        }

        public async Task<Company> GetCompanyProfileByIdAsync(Guid id)
        {
            return await _context.Companies
                .Include(c => c.Industry)
                .Include(c => c.Location)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            try
            {
                _context.Companies.Update(company);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating company with ID {company.Id}: {ex.Message}", ex);
            }
        }
    }
}
