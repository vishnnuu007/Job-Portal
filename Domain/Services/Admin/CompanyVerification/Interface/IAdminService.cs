using Domain.Services.Admin.CompanyVerification.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.CompanyVerification.Interface
{
    public interface IAdminService
    {
        Task<bool> VerifyCompanyAsync(Guid Id);
        Task<CompanyProfilesDto> GetCompanyProfileByIdAsync(Guid id);
    }
}
