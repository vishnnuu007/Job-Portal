using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Job_Seeker.Resume.Interfaces
{
    public interface IResumeRepository
    {
        Task<Domain.Models.Resume?> GetByJobSeekerIdAsync(Guid jobSeekerId);
        Task AddAsync(Domain.Models.Resume resume);
        Task UpdateAsync(Domain.Models.Resume resume);
    }
}
