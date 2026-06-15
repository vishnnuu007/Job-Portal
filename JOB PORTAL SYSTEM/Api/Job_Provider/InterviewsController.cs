using AutoMapper;
using Domain.Services.Job_Provider.Interviews.Dto;
using Domain.Services.Job_Provider.Interviews.Interface;
using JOB_PORTAL_SYSTEM.Api.Job_Provider.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;

        public InterviewsController (IInterviewService interviewService , IMapper mapper)
        {
            _interviewService = interviewService;
            _mapper = mapper;
        }

        [Authorize (Roles = "JobProvider" )]
        [HttpPost("ScheduleInterview")]
        public async Task<IActionResult> ScheduleInterview(CreateInterviewRequest createInterviewRequest)
        {

            var interviewDto = _mapper.Map<CreateInterviewDto>(createInterviewRequest);

            var scheduledInterview = await _interviewService.ScheduleInterviewAsync(interviewDto);

            if (!scheduledInterview)
            {
                return BadRequest("Failed to schedule interview");
            }

            return Ok("Interview scheduled successfully");

        }

        [Authorize(Roles = "JobProvider")]
        [HttpGet("{interviewId}/GetInterviewById")]
        public async Task<IActionResult> GetInterviewById(Guid interviewId)
        { 
            var interview = await _interviewService.GetInterviewByIdAsync(interviewId);
            if (interview == null)
                return NotFound();
            return Ok(interview);
        }

        [Authorize(Roles = "JobProvider")]
        [HttpGet("GetInterviews")]
        public async Task<IActionResult> GetInterview()
        {
            try
            {
                var result = await _interviewService.GetInterviewsAsync();

                if (result == null)
                    return NotFound("Interview not found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "JobProvider")]
        [HttpPut("UpdateInterview")]
        public async Task <IActionResult > UpdateInterview([FromBody ] UpdateInterviewDto updateInterviewDto)
        {
            try
            {
                var result = await _interviewService.UpdateInterviewAsync(updateInterviewDto);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "JobProvider")]
        [HttpDelete("{interviewId}/DeleteInterview")]
        public async Task<IActionResult> DeleteInterview(Guid interviewId)
        {
            try
            {

                var interview = await _interviewService.DeleteInterviewAsync(interviewId);
                if (!interview)
                {
                    return NotFound();
                }

                return Ok("Interview deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
