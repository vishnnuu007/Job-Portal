using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Provider.Interviews.Dto;
using Domain.Services.Job_Provider.Interviews.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Interviews
{
    public class InterviewService:IInterviewService 
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InterviewService (IInterviewRepository interviewRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> ScheduleInterviewAsync(CreateInterviewDto interviewdto)
        {
            var interview = _mapper.Map <Interview >(interviewdto);
            return await _interviewRepository.ScheduleInterviewAsync(interview);
        }

        public async Task<List<InterviewResponseDto>> GetInterviewsAsync()
        {
        
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyId")?.Value;

            if (string.IsNullOrEmpty(companyIdClaim))
            {
                throw new Exception("CompanyId not found in token");
            }

            var companyId = Guid.Parse(companyIdClaim);

          
            var interviews = await _interviewRepository.GetInterviewsAsync(companyId);

            return _mapper.Map<List<InterviewResponseDto>>(interviews);

        }
        public async Task<InterviewResponseDto> GetInterviewByIdAsync(Guid interviewId)
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyId")?.Value;

            if (string.IsNullOrEmpty(companyIdClaim))
            {
                throw new Exception("CompanyId not found in token");
            }

            var companyId = Guid.Parse(companyIdClaim);

            var interview = await _interviewRepository.GetInterviewByIdAsync(interviewId);

            if (interview == null ||
                interview.Application == null ||
                interview.Application.Job == null)
            {
                throw new Exception("Interview not found");
            }

            if (interview.Application.Job.CompanyId != companyId)
            {
                throw new Exception("Unauthorized access");
            }

            return _mapper.Map<InterviewResponseDto>(interview);
        }
        public async Task<InterviewResponseDto> UpdateInterviewAsync(UpdateInterviewDto updateInterviewDto)
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyId")?.Value;

            if (string.IsNullOrEmpty(companyIdClaim))
            {
                throw new Exception("CompanyId not found in token");
            }

            var companyId = Guid.Parse(companyIdClaim);

            var interview = await _interviewRepository.GetInterviewByIdAsync(updateInterviewDto.Id);

            if (interview == null ||
                interview.Application == null ||
                interview.Application.Job == null)
            {
                throw new Exception("Interview not found");
            }

            if (interview.Application.Job.CompanyId != companyId)
            {
                throw new Exception("Unauthorized access");
            }

            var updatedInterview = await _interviewRepository.UpdateInterviewAsync(updateInterviewDto);

            return _mapper.Map<InterviewResponseDto>(updatedInterview);
        }
        public async Task<bool> DeleteInterviewAsync(Guid interviewId)
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyId")?.Value;

            if (string.IsNullOrEmpty(companyIdClaim))
                throw new Exception("CompanyId not found in token");

            var companyId = Guid.Parse(companyIdClaim);

            var interview = await _interviewRepository.GetInterviewByIdAsync(interviewId);

            if (interview == null || interview.Application == null || interview.Application.Job == null)
            {
                throw new Exception("Interview not found");
            }

            if (interview.Application.Job.CompanyId != companyId)
            {
                throw new Exception("Unauthorized access");
            }

            return await _interviewRepository.DeleteInterviewAsync(interviewId);
        }
    }
}
