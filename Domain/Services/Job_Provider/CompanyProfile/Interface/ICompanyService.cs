using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Job_Provider.CompanyProfile.DTO;

namespace Domain.Services.Job_Provider.CompanyProfile.Interface
{
    public interface ICompanyService
    {
        Task<CompanyProfileDto> AddCompanyAsync(CreateCompanyProfileRequest request, Guid userId);
        Task<CompanyProfileDto?> GetCompanyByIdAsync(Guid id);
        Task<IEnumerable<CompanyProfileDto>> GetAllCompaniesByProviderIdAsync(Guid providerId);
        Task<CompanyProfileDto?> UpdateCompanyAsync(Guid CompanyId, Company company);
        Task<bool> DeleteCompanyAsync(Guid id);
    }
}
