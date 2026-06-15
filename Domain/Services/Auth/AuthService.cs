using AutoMapper;
using Domain.Enums;
using Domain.Helper;
using Domain.Models;
using Domain.Services.Auth.DTO;
using Domain.Services.Auth.Interface;

namespace Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AuthService(
            IAuthRepository repository,
            IMapper mapper,
            IEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
        }

        // SIGNUP
        public async Task<Guid> Signup(SignupRequestDTO dto)
        {
            var signupRequest =
                _mapper.Map<SignupRequest>(dto);

            var signupId =
                await _repository
                .AddSignupRequest(signupRequest);

            MailRequest mailRequest =
                new MailRequest
                {
                    Subject = "Email Verification",

                    Body =
                    $"https://localhost:7197/api/Signup/verify-email?signupId={signupId}",

                    ToEmail = dto.Email
                };

            await _emailService
                .SendEmailAsync(mailRequest);

            return signupId;
        }

        // VERIFY EMAIL
        public async Task<bool> VerifyEmail(Guid signupId)
        {
            var signup =
                await _repository
                .GetSignupRequest(signupId);

            if (signup == null)
                return false;

            signup.JobStatus =
                JobStatus.Verified;

            await _repository
                .UpdateSignupRequest(signup);

            return true;
        }

        // SET PASSWORD
        public async Task<string> SetPassword(
            Guid signupId,
            PasswordDTO dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                return "Password mismatch";

            var signup =
                await _repository
                .GetSignupRequest(signupId);

            if (signup == null)
                return "Signup request not found";

            if (signup.JobStatus != JobStatus.Verified)
                return "Email not verified";

            var existingUser =
                await _repository
                .GetUserByEmail(signup.Email);

            if (existingUser != null)
                return "User already exists";

            Guid userId = Guid.NewGuid();

            AuthUser authUser =
                new AuthUser
                {
                    Id = userId,
                    UserName = signup.UserName,
                    FirstName = signup.FirstName,
                    LastName = signup.LastName,
                    Email = signup.Email,
                    PhoneNumber = signup.Phone,

                    // PLAIN TEXT PASSWORD
                    Password = dto.Password,

                    Role = signup.Role
                };

            await _repository
                .AddAuthUser(authUser);

            // JOB SEEKER
            if (signup.Role == Role.JobSeeker)
            {
                Domain.Models.JobSeeker seeker =
                    new Domain.Models.JobSeeker
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Username = signup.UserName,
                        FirstName = signup.FirstName,
                        LastName = signup.LastName,
                        Email = signup.Email,
                        Phone = signup.Phone,
                        Role = (int)Role.JobSeeker
                    };

                await _repository
                    .AddJobSeeker(seeker);
            }

            // JOB PROVIDER
            else if (signup.Role == Role.JobProvider)
            {
                JobProvider provider =
                    new JobProvider
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        UserName = signup.UserName,
                        FirstName = signup.FirstName,
                        LastName = signup.LastName,
                        CreatedAt = DateTime.Now
                    };

                await _repository
                    .AddJobProvider(provider);
            }

            signup.JobStatus =
                JobStatus.Created;

            await _repository
                .UpdateSignupRequest(signup);

            return "Account Created Successfully";
        }

        // LOGIN
        public async Task<LoginDTO> Login(LoginrequestDto dto)
        {
            var user = await _repository.GetUserByEmail(dto.Email);

            if (user == null)
                return null;

            if (dto.Password != user.Password)
                return null;

            var result = _mapper.Map<LoginDTO>(user);

            // JOB SEEKER
            if (user.Role == Role.JobSeeker)
            {
                var seeker = await _repository.GetJobSeekerByUserId(user.Id);

                if (seeker == null)
                    return null;

                result.JobSeekerId = seeker.Id;

                // token WITHOUT company id
                result.Token = _repository.CreateToken(user, null);
            }

            // JOB PROVIDER
            else if (user.Role == Role.JobProvider)
            {
                var provider = await _repository.GetJobProviderByUserId(user.Id);

                if (provider == null)
                    return null;

                result.JobProviderId = provider.Id;

                // 🔥 MUST PASS THIS
                result.Token = _repository.CreateToken(user, provider.CompanyId);
            }

            return result;
        }

        // FORGET PASSWORD
        public async Task<string> ForgetPassword(
            ForgetPasswordDTO dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
                return "Password mismatch";

            var user =
                await _repository
                .GetUserByEmail(dto.Email);

            if (user == null)
                return "User not found";

            // PLAIN TEXT PASSWORD
            user.Password = dto.NewPassword;

            await _repository
                .UpdateUser(user);

            return "Password Updated Successfully";
        }
    }
}
