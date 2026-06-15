using Domain.Services.Job_Seeker.Applications.DTOs;
using Domain.Services.Job_Seeker.Applications.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Route("api/v1/jobseekers/{jobSeekerId}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _service;

        public JobApplicationsController(IJobApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob(Guid jobSeekerId, [FromBody] ApplyJobDto dto)
        {
            try
            {
                await _service.ApplyJobAsync(jobSeekerId, dto);

                return Created("", new
                {
                    success = true,
                    message = "Job application submitted successfully"
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
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

        [HttpGet]
        public async Task<IActionResult> GetMyApplications(Guid jobSeekerId)
        {
            try
            {
                var result = await _service.GetMyApplicationsAsync(jobSeekerId);

                return Ok(new
                {
                    success = true,
                    message = "Applications fetched successfully",
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
