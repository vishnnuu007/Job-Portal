using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Services.Admin.CompanyVerification.Dto;
using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Dto;
using Domain.Services.Auth.DTO;
using Domain.Services.Job_Provider.Candidate.Dto;
using Domain.Services.Job_Provider.CompanyProfile.DTO;
using Domain.Services.Job_Provider.Interviews.Dto;
using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Job_Provider.ViewCompanyApplications.Dto;
using Domain.Services.Job_Provider.ViewJobs.Dto;
using Domain.Services.Job_Seeker.Applications.DTOs;
using Domain.Services.Job_Seeker.Interviews.DTOs;
using Domain.Services.Job_Seeker.SavedJobs.DTOs;
using Domain.Services.Job_Seeker.SavedJobs.DTOs;
using Domain.Services.Jobs.DTOs;
using Domain.Services.Jobs.DTOs;
using Domain.Services.JobSeeker_Module.Profile.DTO;
using Domain.Services.JobSeeker_Module.Profile.DTO;
using JOB_PORTAL_SYSTEM.Api.ADMIN.RequestObjects;
using JOB_PORTAL_SYSTEM.Api.ADMIN.RequestObjects;
using JOB_PORTAL_SYSTEM.Api.Job_Provider.RequestObjects;
using JOB_PORTAL_SYSTEM.Api.Job_Provider.RequestObjects;
using JOB_PORTAL_SYSTEM.Api.Job_ProviderModule.RequestObject;
using JOB_PORTAL_SYSTEM.Api.Job_ProviderModule.RequestObject;


namespace JOB_PORTAL_SYSTEM.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateCompanyProfileRequest, Company>();
            CreateMap<UpdateCompanyProfileRequest, Company>();
            CreateMap<Company, CompanyProfileDto>()
                .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Industry != null ? src.Industry.Name : string.Empty))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : string.Empty));




            CreateMap<Job, JobDto>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company != null ? src.Company.CompanyName : string.Empty))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : string.Empty))
                .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(src => src.CompanyMember != null ? src.CompanyMember.Name : string.Empty))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.CompanyMember != null ? src.CompanyMember.Role : CompanyRole.Recruiter));
            CreateMap<CreateJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();

            //CreateMap<Domain.JobProviderSignupRequestDto, SignupRequest>().ReverseMap();
            //CreateMap<JobProviderSignupRequest, JobProviderSignupRequestDto>().ReverseMap();
            CreateMap<AuthUser, JobProvider>().ReverseMap();
            //CreateMap<AuthUser, JobproviderLoginDto>();
            CreateMap<CreateInterviewDto, Interview>().ReverseMap();
            CreateMap<Interview, InterviewResponseDto>().ReverseMap();
            CreateMap<CreateInterviewRequest, CreateInterviewDto>();
            CreateMap<SignupRequestDTO, SignupRequest>().ReverseMap();



            CreateMap<AuthUser, JobProvider>().ReverseMap();
            CreateMap<AuthUser, LoginDTO>().ReverseMap();

            CreateMap<Company, VerifyCompanyDto>().ReverseMap();
            CreateMap<VerifyCompanyDto, VerifyCompanyRequest>().ReverseMap();

            CreateMap<Company, CompanyProfilesDto>().ReverseMap();
            CreateMap<CompanyProfilesDto, CompanyProfileRequest>().ReverseMap();

            CreateMap<Job, JobStatsDto>().ReverseMap();
            CreateMap<JobStatsDto, JobStatsRequest>().ReverseMap();

            CreateMap<Skill, AddSkillDto>().ReverseMap();
            CreateMap<AddSkillDto, AddSkillRequest>().ReverseMap();
            

            CreateMap<ApplyJobDto, JobApplication>();

            CreateMap<Skill, UpdateSkillDto>().ReverseMap();
            CreateMap<UpdateSkillDto, UpdateSkillRequest>().ReverseMap();

            CreateMap<Skill, DeleteSkillDto>().ReverseMap();
            CreateMap<DeleteSkillDto, DeleteSkillRequest>().ReverseMap();
            CreateMap<SignupRequestDTO, SignupRequest>().ReverseMap();
            CreateMap<AuthUser, LoginDTO>().ReverseMap();

            CreateMap<CreateJobSeekerProfileDto, JobSeekerProfile>();
            CreateMap<UpdateJobSeekerProfileDto, JobSeekerProfile>();
            CreateMap<JobSeekerProfile, JobSeekerProfileResponseDto>();

            CreateMap<JobApplication, MyApplicationDto>()
                .ForMember(dest => dest.JobId,
                    opt => opt.MapFrom(src => src.JobId))

                .ForMember(dest => dest.JobTitle,
                    opt => opt.MapFrom(src => src.Job != null ? src.Job.Title : string.Empty))

                .ForMember(dest => dest.CompanyName,
                    opt => opt.MapFrom(src =>
                        src.Job != null && src.Job.Company != null
                            ? src.Job.Company.CompanyName
                            : string.Empty))

                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()))

                .ForMember(dest => dest.AppliedDate,
                    opt => opt.MapFrom(src => src.AppliedDate));

            CreateMap<Interview, InterviewDto>()
                .ForMember(dest => dest.JobTitle,
                    opt => opt.MapFrom(src =>
                        src.Application != null && src.Application.Job != null
                            ? src.Application.Job.Title
                            : string.Empty))

                .ForMember(dest => dest.Mode,
                    opt => opt.MapFrom(src => src.Mode.ToString()))

                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()))

                .ForMember(dest => dest.InterviewDate,
                    opt => opt.MapFrom(src => src.InterviewDate));

            CreateMap<Job, GetJobsDto>()
               .ForMember(dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id))

               .ForMember(dest => dest.Title,
                   opt => opt.MapFrom(src => src.Title))

               .ForMember(dest => dest.CompanyName,
                   opt => opt.MapFrom(src =>
                       src.Company != null ? src.Company.CompanyName : string.Empty))

               .ForMember(dest => dest.Location,
                   opt => opt.MapFrom(src =>
                       src.Location != null ? src.Location.Name : string.Empty))

               .ForMember(dest => dest.Salary,
                   opt => opt.MapFrom(src => src.Salary));

            CreateMap<SavedJob, SavedJobsResponseDto>()
                .ForMember(dest => dest.JobTitle,
                opt => opt.MapFrom(src => src.Job.Title))

                .ForMember(dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Job.Company.CompanyName));

            CreateMap<AuthUser, LoginrequestDto>().ReverseMap();

            CreateMap<CreateJobSeekerProfileDto, JobSeekerProfile>();
            //.ForMember(dest => dest.Location,
            //opt => opt.MapFrom(src => src.Job.Location.Name));



            CreateMap<JobApplication, CompanyApplicationDto>()
    .ForMember(dest => dest.ApplicationId,
        opt => opt.MapFrom(src => src.Id))

    .ForMember(dest => dest.JobTitle,
        opt => opt.MapFrom(src => src.Job.Title))

    .ForMember(dest => dest.CandidateName,
        opt => opt.MapFrom(src =>
            src.JobSeeker.FirstName + " " + src.JobSeeker.LastName));
        

            CreateMap<JobApplication, CompanyApplicationDto>()
.ForMember(dest => dest.ApplicationId,
   opt => opt.MapFrom(src => src.Id))

.ForMember(dest => dest.JobTitle,
   opt => opt.MapFrom(src => src.Job.Title))

.ForMember(dest => dest.CandidateName,
   opt => opt.MapFrom(src =>
       src.JobSeeker.FirstName + " " + src.JobSeeker.LastName));



            CreateMap<Job, ViewCompanyJobDto>()
    .ForMember(dest => dest.JobId,
        opt => opt.MapFrom(src => src.Id))

    .ForMember(dest => dest.CategoryName,
        opt => opt.MapFrom(src => src.Category.Name))

    .ForMember(dest => dest.LocationName,
        opt => opt.MapFrom(src => src.Location.Name));


            CreateMap<JobSeeker, CandidateDto>()
    .ForMember(dest => dest.CandidateId,
        opt => opt.MapFrom(src => src.Id))

    .ForMember(dest => dest.CandidateName,
        opt => opt.MapFrom(src =>
            src.FirstName + " " + src.LastName))

    .ForMember(dest => dest.ProfileName,
        opt => opt.MapFrom(src => src.Profile.ProfileName))

    .ForMember(dest => dest.ProfileDescription,
        opt => opt.MapFrom(src => src.Profile.ProfileDescription))

    .ForMember(dest => dest.Experience,
        opt => opt.MapFrom(src => src.Profile.Experience));

        }
    }
}

