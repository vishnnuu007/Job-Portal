using Domain.Services.JobSeeker_Module.Profile.DTO;
using Domain.Services.JobSeeker_Module.Profile.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JOB_PORTAL_SYSTEM.Api.Job_Seeker
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerProfileController : ControllerBase
    {
        private readonly IJobSeekerProfileService _service;

        public JobSeekerProfileController(IJobSeekerProfileService service)
        {
            _service = service;
        }

        [HttpPost("create-profile")]
        public async Task<IActionResult> CreateProfile([FromBody] CreateJobSeekerProfileDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get user id from JWT token
        
            var userIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;


            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("User not logged in");
            }

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return BadRequest("Invalid User Id");
            }

            var result = await _service.CreateAsync(userId, dto);

            return Ok(result);
        }



        [HttpGet("get-profile")]
        public async Task<IActionResult> GetProfile()
        {

            var userIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;


            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("User not logged in");
            }

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return BadRequest("Invalid User Id");
            }

            var result = await _service.GetProfileAsync(userId);

            return Ok(result);
        }


        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateJobSeekerProfileDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;


            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("User not logged in");
            }

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return BadRequest("Invalid User Id");
            }

            var result = await _service.UpdateAsync(userId, dto);

            return Ok(result);
        }

        [HttpDelete("delete-profile")]
        public async Task<IActionResult> DeleteProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;


            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User not logged in");

            if (!Guid.TryParse(userIdClaim, out Guid userId))
                return BadRequest("Invalid User Id");

            var result = await _service.DeleteAsync(userId);

            return Ok(result);
        }
    }
}