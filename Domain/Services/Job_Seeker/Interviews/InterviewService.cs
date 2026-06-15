using AutoMapper;
using Domain.Services.Job_Seeker.Interviews.DTOs;
using Domain.Services.Job_Seeker.Interviews.Interfaces;

namespace Domain.Services.Job_Seeker.Interviews
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _repo;
        private readonly IMapper _mapper;

        public InterviewService(IInterviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<InterviewDto>> GetMyInterviewsAsync(Guid jobSeekerId)
        {
            var interviews = await _repo.GetByJobSeekerIdAsync(jobSeekerId);

            return _mapper.Map<List<InterviewDto>>(interviews);
        }
    }
}
