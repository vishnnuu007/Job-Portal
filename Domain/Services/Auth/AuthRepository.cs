using Domain.Data;
using Domain.Enums;
using Domain.Models;
using Domain.Services.Auth.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Services.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthRepository(
            AppDbContext context,
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<Guid> AddSignupRequest(
            SignupRequest request)
        {
            request.JobStatus =
                Enums.JobStatus.Pending;

            await _context.SignupRequests
                .AddAsync(request);

            await _context.SaveChangesAsync();

            return request.Id;
        }

        public async Task<SignupRequest> GetSignupRequest(Guid id)
        {
            return await _context.SignupRequests
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateSignupRequest(
            SignupRequest request)
        {
            _context.SignupRequests.Update(request);

            await _context.SaveChangesAsync();
        }

        public async Task<AuthUser> GetUserByEmail(
            string email)
        {
            return await _context.AuthUsers
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAuthUser(AuthUser user)
        {
            await _context.AuthUsers.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task AddJobSeeker(
            Domain.Models.JobSeeker seeker)
        {
            await _context.JobSeekers.AddAsync(seeker);

            await _context.SaveChangesAsync();
        }

        public async Task AddJobProvider(
            JobProvider provider)
        {
            await _context.JobProviders.AddAsync(provider);

            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Models.JobSeeker>
            GetJobSeekerByUserId(Guid userId)
        {
            return await _context.JobSeekers
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<JobProvider>
            GetJobProviderByUserId(Guid userId)
        {
            return await _context.JobProviders
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<AuthUser> GetAdminUserById(Guid id)
        {
            return await _context.AuthUsers
                .FirstOrDefaultAsync(x => x.Id == id && x.Role == Role.Admin);
        }

        public async Task UpdateUser(AuthUser user)
        {
            _context.AuthUsers.Update(user);

            await _context.SaveChangesAsync();
        }

        // JWT TOKEN
        public string CreateToken(AuthUser user, Guid? companyId)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string? tokenSecret =
                _config["AuthSettings:Token"];

            if (string.IsNullOrWhiteSpace(tokenSecret))
                throw new Exception("JWT Secret Missing");

            List<Claim> claims =
                new List<Claim>
                {
                    new Claim(
                        ClaimTypes.Name,
                        user.UserName),

                    new Claim(
                        ClaimTypes.Email,
                        user.Email),

                    new Claim(
                        ClaimTypes.Sid,
                        user.Id.ToString()),

                    new Claim(
                        ClaimTypes.Role,
                        user.Role.ToString()),

                    new Claim(
                "CompanyId",
                companyId.ToString())

                };

            

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(tokenSecret));

            var creds =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha512Signature);

            var token =
                new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}