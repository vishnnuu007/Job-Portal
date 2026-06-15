using AutoMapper;
using Domain.Services.Admin.CompanyVerification.Dto;
using Domain.Services.Admin.CompanyVerification.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.CompanyVerification
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _companyRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<bool> VerifyCompanyAsync(Guid userId)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(userId);

                if (company == null)
                    return false;

                company.IsVerified = true;
                company.CreatedAt = DateTime.UtcNow;

                await _companyRepository.UpdateCompanyAsync(company);

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return false;
            }
        }

        public async Task<CompanyProfilesDto> GetCompanyProfileByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);

            if (company == null)
                return null;

            return _mapper.Map<CompanyProfilesDto>(company);
        }

    }
}
