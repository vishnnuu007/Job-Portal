using Domain.Services.Job_Provider.ViewCompanyApplications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Authorize(Roles = "JobProvider")]
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetApplicationsByCompany(Guid companyId)
        {
            var applications = await _applicationService.GetApplicationsByCompanyAsync(companyId);

            return Ok(applications);
        }
    }
}
