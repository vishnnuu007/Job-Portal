using Domain.Data;
using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;
using Domain.Services.Jobs.Interfaces;
using JOB_PORTAL_SYSTEM.Api.Admin.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JOB_PORTAL_SYSTEM.Api.Admin
{
    [Tags("02-Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILocationRepository _locationRepository;
        private readonly IQualificationService _qualificationService;
        private readonly AppDbContext _context;
        private readonly Domain.Services.Admin.CompanyVerification.Interface.IAdminService _companyService;
        private readonly IJobService _jobService;
        private readonly ISkillService _skillService;
        public AdminController(IUserService userService, ILocationRepository locationRepository, IQualificationService qualificationService, AppDbContext context, Domain.Services.Admin.CompanyVerification.Interface.IAdminService companyService, IJobService jobService, ISkillService skillService)
        {

            _userService = userService;
            _locationRepository = locationRepository;
            _qualificationService = qualificationService;
            _context = context;
            _companyService = companyService;
            _jobService = jobService;
            _skillService = skillService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound("User Not Found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("company-verification/{Id}/verify")]
        public async Task<IActionResult> VerifyCompany(Guid Id)
        {
            try
            {
                var result = await _companyService.VerifyCompanyAsync(Id);

                if (!result)
                    return NotFound("Company not found");

                return Ok("Company verified successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("profiles/{id}")]
        public async Task<IActionResult> GetCompanyProfile(Guid id)
        {
            try
            {
                var profile = await _companyService.GetCompanyProfileByIdAsync(id);

                if (profile == null)
                    return NotFound();

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("stats/{companyId}")]
        public async Task<IActionResult> GetJobStats(Guid companyId)
        {
            try
            {
                var stats = await _jobService.GetJobStatsAsync(companyId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("location")]
        public async Task<IActionResult> AddLocation(AddLocationDto dto)
        {
            try
            {
                var result = await _locationRepository
                    .AddLocationAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-skills")]
        public async Task<IActionResult> AddSkills([FromBody] List<AddSkillDto> skills)
        {
            try
            {
                foreach (var skill in skills)
                {
                    skill.Id = Guid.NewGuid();
                    await _skillService.AddSkillAsync(skill);
                }
                return Ok("Skills added successfully");
                //var skill = await _skillService.AddSkillAsync(skillId);
                //return Ok("Skills added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("skills/{skillId}")]
        public async Task<IActionResult> GetSkillById(Guid skillId)
        {
            try
            {
                var skill = await _skillService.GetSkillByIdAsync(skillId);
                if (skill == null)
                    return NotFound("Skill not found");
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("update-skills")]
        public async Task<IActionResult> UpdateSkills([FromBody] List<UpdateSkillDto> skills)
        {
            try
            {
                foreach (var skill in skills)
                {
                    await _skillService.UpdateSkillAsync(skill);
                }
                return Ok("Skills updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("delete-skills/{skillId}")]
        public async Task<IActionResult> DeleteSkills(Guid skillId)
        {
            try
            {
                var result = await _skillService.DeleteSkillAsync(skillId);
                if (result == null)
                    return NotFound("Skill not found");
                return Ok("Skill deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("qualification")]
        public async Task<IActionResult> AddQualification(AddQualificationDto dto)
        {
            try
            {
                var result = await _qualificationService.AddQualificationAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost("logout")]

        //public IActionResult Logout()
        //{
        //    return Ok("Logged Out Successfully");
        //}

    }
}