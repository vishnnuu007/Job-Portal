using Domain.Services.Member.DTO;
using Domain.Services.Member.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Job_ProviderModule
{


    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationservice _service;

        public ApplicationController(IApplicationservice service)
        {
            _service = service;
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateApplicationStatus dto)
        {
            var result = await _service.UpdateStatusAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}