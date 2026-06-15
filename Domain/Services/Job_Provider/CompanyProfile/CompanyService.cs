using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Provider.CompanyProfile.DTO;
using Domain.Services.Job_Provider.CompanyProfile.Interface;


namespace Domain.Services.Job_Provider.CompanyProfile
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<CompanyProfileDto> AddCompanyAsync(CreateCompanyProfileRequest request, Guid userId)
        {
            try
            {
                var jobProvider = await companyRepository.GetByUserIdAsync(userId);

                if (jobProvider == null)
                {
                    throw new Exception("Job provider not found");
                }

                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    CompanyName = request.CompanyName,
                    Description = request.Description,
                    IndustryId = request.IndustryId,
                    LocationId = request.LocationId,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    ProviderId = jobProvider.Id,
                    CreatedAt = DateTime.UtcNow,
                    IsVerified = false
                };

                await companyRepository.AddAsync(company);

                var savedcompany = await companyRepository.GetByIdAsync(company.Id);

                return mapper.Map<CompanyProfileDto>(savedcompany);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<CompanyProfileDto?> GetCompanyByIdAsync(Guid Id)
        {
            try
            {
                var company = await companyRepository.GetByIdAsync(Id);
                return company == null ? null : mapper.Map<CompanyProfileDto>(company);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CompanyProfileDto>> GetAllCompaniesByProviderIdAsync(Guid providerId)
        {
            try
            {

                var companies = await companyRepository.GetAllByUserIdAsync(providerId);

                return companies.Select(c => mapper.Map<CompanyProfileDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CompanyProfileDto?> UpdateCompanyAsync(Guid CompanyId, Company company)
        {
            try
            {
                var existingCompany = await companyRepository.GetByIdAsync(CompanyId);
                if (existingCompany == null)
                {
                    throw new Exception("Company not found");
                }
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.Description = company.Description;
                existingCompany.IndustryId = company.IndustryId;
                existingCompany.LocationId = company.LocationId;
                existingCompany.Address = company.Address;
                existingCompany.PhoneNumber = company.PhoneNumber;

                var updatedCompany = await companyRepository.UpdateAsync(CompanyId, existingCompany);
                return mapper.Map<CompanyProfileDto>(updatedCompany);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            try
            {
                var existingCompany = await companyRepository.GetByIdAsync(id);
                if (existingCompany == null)
                {
                    throw new Exception("Company not found");
                }
                return await companyRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}