using Domain.Services.Job_Seeker.Interviews.Interfaces;
using Domain.Services.Job_Seeker.SavedJobs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Route("/api/v1/jobseekers/{jobSeekerId}/interviews")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _service;
        private readonly ISavedJobService _save;

        public InterviewsController(IInterviewService service, ISavedJobService save)
        {
            _service = service;
            _save = save;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyInterviews(Guid jobSeekerId)
        {
            var result = await _service.GetMyInterviewsAsync(jobSeekerId);

            return Ok(new
            {
                success = true,
                message = "Interviews fetched successfully",
                data = result
            });
        }


    }
}
