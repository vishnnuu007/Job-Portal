using Domain.Services.Job_Provider.ViewJobs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewJobsController : ControllerBase
    {
        private readonly IViewJobService _viewJobService;

        public ViewJobsController (IViewJobService viewJobService)
        {
            _viewJobService = viewJobService;
        }

        [Authorize(Roles = "JobProvider")]
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> ViewJobsByCompanyId(Guid companyId)
        {
            var jobs = await _viewJobService.ViewJobsByCompanyIdAsync(companyId);
            return Ok(jobs);
        }
    }
}
