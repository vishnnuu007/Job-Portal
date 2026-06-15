using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Provider.CompanyProfile.DTO;
using Domain.Services.Job_Provider.CompanyProfile.Interface;
using JOB_PORTAL_SYSTEM.Api.Job_ProviderModule.RequestObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider
{

    [Tags("03-ProviderCompany")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "JobProvider")]
    public class ProviderCompanyController : ControllerBase
    {
        readonly ICompanyService companyService;
        readonly IMapper mapper;
        public ProviderCompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyProfile([FromBody] Domain.Services.Job_Provider.CompanyProfile.DTO.CreateCompanyProfileRequest request)
        {
            try
            {
                // Get JobProviderId from JWT Token
                var providerIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;

                if (string.IsNullOrEmpty(providerIdClaim))
                {
                    return Unauthorized("Invalid token");
                }

                Guid providerId = Guid.Parse(providerIdClaim);

                var company = await companyService.AddCompanyAsync(request, providerId);

                var response = mapper.Map<CompanyProfileDto>(company);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetCompanyProfileByUserId(Guid providerId)
        {
            try
            {
                var company = await companyService.GetAllCompaniesByProviderIdAsync(providerId);
                var response = mapper.Map<IEnumerable<CompanyProfileDto>>(company);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCompanyProfileById(Guid id)
        {
            try
            {
                var company = await companyService.GetCompanyByIdAsync(id);
                if (company == null)
                {
                    return NotFound("Company not found");
                }
                var response = mapper.Map<CompanyProfileDto>(company);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{CompanyId}")]
        [Authorize]

        public async Task<IActionResult> UpdateCompanyProfile(Guid CompanyId, [FromBody] UpdateCompanyProfileRequest request)
        {
            try
            {
                var company = mapper.Map<Company>(request);
                var updatedCompany = await companyService.UpdateCompanyAsync(CompanyId, company);
                if (updatedCompany == null)
                {
                    return NotFound("Company not found");
                }
                var response = mapper.Map<CompanyProfileDto>(updatedCompany);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCompanyProfile(Guid id)
        {
            try
            {
                var deleted = await companyService.DeleteCompanyAsync(id);
                if (!deleted)
                {
                    return NotFound("Company not found");
                }
                return Ok("Company Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
