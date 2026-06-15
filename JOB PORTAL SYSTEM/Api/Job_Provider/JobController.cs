using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Jobs.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_Provider
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="JobProvider")]
    

    public class JobController : ControllerBase
    {
        IJobService jobService;
        IMapper mapper;
        public JobController(IJobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobDto dto)
        {
            try
            {
                //var job = mapper.Map<Job>(dto);

                //job.Id = Guid.NewGuid();
                //job.CreatedAt = DateTime.UtcNow;

                var createdJob = await jobService.CreateJobAsync(dto);

                return CreatedAtAction(nameof(GetJob), new { id = createdJob.Id }, createdJob);

            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(Guid id)
        {
            try
            {
                var job = await jobService.GetJobByIdAsync(id);
                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            try
            {
                var jobs = await jobService.GetAllJobsAsync();
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromBody] UpdateJobDto dto)
        {
            try
            {


                // Pass entity into service
                var updatedJob = await jobService.UpdateJobAsync(id, dto);

                return Ok(updatedJob);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            try
            {
                var job = await jobService.GetJobByIdAsync(id);
                if (job == null)
                {
                    return BadRequest();
                }

                await jobService.DeleteJobAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return BadRequest(ex.Message);
            }
        }
    }
}