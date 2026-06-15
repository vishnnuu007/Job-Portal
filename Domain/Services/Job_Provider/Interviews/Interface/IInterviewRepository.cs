using Domain.Models;
using Domain.Services.Job_Provider.Interviews.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Interviews.Interface
{
    public interface IInterviewRepository
    {
        Task<bool> ScheduleInterviewAsync(Interview interview);
        Task<List<Interview>> GetInterviewsAsync(Guid companyId);
        Task<Interview> GetInterviewByIdAsync(Guid interviewId);
        Task<InterviewResponseDto> UpdateInterviewAsync(UpdateInterviewDto updateInterviewDto);
        Task<bool> DeleteInterviewAsync(Guid interviewId);
    }
}
