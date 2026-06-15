using Domain.Services.Job_Seeker.Resume.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Job_Seeker.Resume.Interfaces
{
    public interface IResumeService
    {
        Task UploadResumeAsync(Guid jobSeekerId, UploadResumeDto dto);
    }
}
