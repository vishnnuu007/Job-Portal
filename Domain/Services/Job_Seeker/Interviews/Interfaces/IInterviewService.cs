using Domain.Services.Job_Seeker.Interviews.DTOs;

namespace Domain.Services.Job_Seeker.Interviews.Interfaces
{
    public interface IInterviewService
    {
        Task<List<InterviewDto>> GetMyInterviewsAsync(Guid jobSeekerId);
    }
}
