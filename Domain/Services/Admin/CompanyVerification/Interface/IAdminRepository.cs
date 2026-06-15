using Domain.Models;
using Domain.Services.Admin.CompanyVerification.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.CompanyVerification.Interface
{
    public interface IAdminRepository
    {
        Task<Company> GetCompanyByIdAsync(Guid Id);
        Task<Company> GetCompanyProfileByIdAsync(Guid id);
        Task UpdateCompanyAsync(Company company);
    }
}
