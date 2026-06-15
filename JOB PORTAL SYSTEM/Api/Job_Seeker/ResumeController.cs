using Domain.Services.Job_Seeker.Resume.DTOs;
using Domain.Services.Job_Seeker.Resume.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Route("api/v1/jobseekers/{jobSeekerId}/resume")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _service;

        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        // ✔ UPLOAD / REPLACE RESUME
        [HttpPost]
        public async Task<IActionResult> UploadResume(Guid jobSeekerId, [FromForm] UploadResumeDto dto)
        {
            try
            {
                await _service.UploadResumeAsync(jobSeekerId, dto);

                return Ok(new
                {
                    success = true,
                    message = "Resume uploaded successfully",
                    fileName = dto.File.FileName
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
