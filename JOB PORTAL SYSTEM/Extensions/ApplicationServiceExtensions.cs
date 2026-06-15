using Domain.Data;
using Domain.Helper;
using Domain.Services;
using Domain.Services.Admin.CompanyVerification;
using Domain.Services.Admin.CompanyVerification.Interface;
using Domain.Services.Admin.Interface;
using Domain.Services.Admin.Repository;
using Domain.Services.Admin.Services;
using Domain.Services.Job_Provider.Candidate;
using Domain.Services.Job_Provider.Candidate.Interface;
using Domain.Services.Job_Provider.CompanyProfile;
using Domain.Services.Job_Provider.CompanyProfile.Interface;
using Domain.Services.Job_Provider.Interviews;
using Domain.Services.Job_Provider.Interviews.Interface;
using Domain.Services.Job_Provider.ViewCompanyApplications;
using Domain.Services.Job_Provider.ViewCompanyApplications.Interface;
using Domain.Services.Job_Provider.ViewJobs;
using Domain.Services.Job_Provider.ViewJobs.Interface;
using Domain.Services.Job_Seeker.Resume;
using Domain.Services.Job_Seeker.Resume.Interfaces;
using Domain.Services.Jobs;
using Domain.Services.Jobs.Interfaces;
using Domain.Services.JobSeeker_Module.Profile.Interface;
using Domain.Services.JobSeeker_Module.Profile.Repository;
using Domain.Services.JobSeeker_Module.Profile.Service;
using Domain.Services.Member.Interface;
using Domain.Services.Member.Repository;
using Domain.Services.Member.Service;
using Microsoft.EntityFrameworkCore;

namespace JOB_PORTAL_SYSTEM.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

           

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();

           
            services.AddScoped<Domain.Services.Auth.Interface.IAuthRepository, Domain.Services.Auth.AuthRepository>();
            services.AddScoped<Domain.Services.Auth.Interface.IAuthService, Domain.Services.Auth.AuthService>();


            services.AddScoped<IJobSeekerProfileService,JobSeekerProfileService>();
            services.AddScoped<IJobSeekerProfileRepository,JobSeekerProfileRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<IInterviewRepository, InterviewRepository>();


            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IQualificationService, QualificationService>();

            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<IResumeService, ResumeService>();



            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();


            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, CompanyMemberService>();
            services.AddScoped<Domain.Services.Member.Interface.IApplicationRepository, Domain.Services.Member.Repository.ApplicationRepository>();
            services.AddScoped<IApplicationservice, Domain.Services.Member.Service.ApplicationService>();
            


            services.AddScoped<Domain.Services.Job_Seeker.Interviews .Interfaces.IInterviewRepository , Domain.Services.Job_Seeker.Interviews .InterviewRepository >();

            services.AddScoped<Domain.Services.Job_Seeker.Interviews.Interfaces.IInterviewService , Domain.Services.Job_Seeker.Interviews .InterviewService >();


            services.AddScoped<Domain.Services.Job_Seeker.Applications.Interfaces.IJobApplicationService,Domain.Services.Job_Seeker.Applications.JobApplicationService>();

            services.AddScoped<Domain.Services.Job_Seeker.Applications.Interfaces.IJobApplicationRepository,Domain.Services.Job_Seeker.Applications.JobApplicationRepository>();

            services.AddScoped<ICandidateService, CandidateService>();
            services .AddScoped <ICandidateRepository , CandidateRepository>();

            services.AddScoped<IViewJobRepository, ViewJobRepository>();
            services.AddScoped<IViewJobService, ViewJobService>();

            services.AddScoped<Domain.Services.Job_Provider.ViewCompanyApplications.Interface.IApplicationRepository, Domain.Services.Job_Provider.ViewCompanyApplications.ApplicationRepository>();
            services .AddScoped <IApplicationService , Domain.Services.Job_Provider.ViewCompanyApplications.ApplicationService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            return services;
        }
    }
}
