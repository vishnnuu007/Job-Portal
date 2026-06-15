using Domain.Services.Job_Seeker.SavedJobs.DTOs;
using Domain.Services.Job_Seeker.SavedJobs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Route("api/v1/jobseekers/{jobSeekerId}/saved-jobs")]
    [ApiController]
    public class SavedJobsController : ControllerBase
    {
        private readonly ISavedJobService _service;

        public SavedJobsController(ISavedJobService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveJob(Guid jobSeekerId, [FromBody] SavedJobDto dto)
        {
            try
            {
                await _service.SavedJobAsync(jobSeekerId, dto);

                return Created("", new
                {
                    success = true,
                    message = "Job saved successfully"
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
        public async Task<IActionResult> GetSavedJobs(Guid jobSeekerId)
        {
            try
            {
                var result = await _service.GetSavedJobsAsync(jobSeekerId);

                return Ok(new
                {
                    success = true,
                    message = "Saved jobs fetched successfully",
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

        [HttpDelete("{jobId}")]
        public async Task<IActionResult> DeleteSavedJob(Guid jobId, Guid jobSeekerId)
        {
            try
            {
                await _service.RemoveSavedJobAsync(jobSeekerId, jobId);

                return Ok(new
                {
                    success = true,
                    message = "Removed saved job successfully"
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
