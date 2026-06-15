using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth.Interface
{
    public interface IAuthRepository
    {
        Task<Guid> AddSignupRequest(SignupRequest request);
        Task<SignupRequest> GetSignupRequest(Guid id);
        Task UpdateSignupRequest(SignupRequest request);
        Task<AuthUser> GetUserByEmail(string email);
        Task AddAuthUser(AuthUser user);
        Task AddJobSeeker(Domain.Models.JobSeeker seeker);
        Task AddJobProvider(JobProvider provider);
        Task<Domain.Models.JobSeeker> GetJobSeekerByUserId(Guid userId);
        Task<JobProvider> GetJobProviderByUserId(Guid userId);
        Task UpdateUser(AuthUser user);
        string CreateToken(AuthUser user, Guid? companyId);
    }
}
