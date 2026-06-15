using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.CompanyProfile.Interface
{
    public interface ICompanyRepository
    {
        Task<Company> AddAsync(Company company);
        Task<Company?> GetByIdAsync(Guid id);
        Task<IEnumerable<Company>> GetAllByUserIdAsync(Guid companyId);
        Task<Company?> UpdateAsync(Guid CompanyId, Company company);
        Task<bool> DeleteAsync(Guid id);
        //---------------------------------------------------------------//
        public Task<JobProvider?> GetByUserIdAsync(Guid userId);
        public Task UpdateAsync(JobProvider jobProvider);

        //Task<List<Location?>> GetLocationsByIdAsync(List<Guid> locationIds);
        //Task<List<Industry?>> GetAllIndustriesByIdAsync(List<Guid> industryIds);

    }
}
