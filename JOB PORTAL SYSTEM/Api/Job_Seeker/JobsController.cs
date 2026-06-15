using Domain.Services.Jobs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _service;

        public JobsController(IJobService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            try
            {
                var jobs = await _service.GetAllJobsAsync();

                return Ok(new
                {
                    success = true,
                    message = "Successfully fetched all jobs",
                    data = jobs
                });
            }

            catch (Exception)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Something went wrong"
                });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchJobs([FromQuery] string? keyword)
        {
            try
            {
                var result = await _service.SearchJobsAsync(keyword);

                return Ok(new
                {
                    success = true,
                    message = "Jobs fetched successfully",
                    data = result
                });
            }

            catch (Exception)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Something went wrong"
                });
            }
        }
    }
}
