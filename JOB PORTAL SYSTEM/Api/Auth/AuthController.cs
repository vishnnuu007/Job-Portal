using Domain.Services.Auth.Interface;
using Domain.Services.Auth.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JOB_PORTAL_SYSTEM.Api.Auth
{
    [Tags("01-Auth")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        // ================= SIGNUP =================

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(
            SignupRequestDTO dto)
        {
            try
            {
                var id = await _service.Signup(dto);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ================= VERIFY EMAIL =================

        [HttpGet("verify-email")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(
            Guid signupId)
        {
            try
            {
                var result =
                    await _service.VerifyEmail(signupId);

                if (!result)
                {
                    return BadRequest("Verification failed");
                }

                return Ok("Email Verified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ================= SET PASSWORD =================

        [HttpPost("set-password/{signupId}")]
        [AllowAnonymous]
        public async Task<IActionResult> SetPassword(
            Guid signupId,
            PasswordDTO dto)
        {
            try
            {
                var result =
                    await _service.SetPassword(signupId,dto);

                if (result != "Account Created Successfully")
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ================= LOGIN =================

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(
            LoginrequestDto dto)
        {
            try
            {
                var result =
                    await _service.Login(dto);

                if (result == null)
                {
                    return BadRequest(
                        "Invalid credentials");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ================= FORGET PASSWORD =================

        [HttpPost("forget-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(
            ForgetPasswordDTO dto)
        {
            try
            {
                var result =
                    await _service.ForgetPassword(dto);

                if (result !=
                    "Password Updated Successfully")
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,JobSeeker,JobProvider")]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok("Logged Out Successfully");
        }


    }
}