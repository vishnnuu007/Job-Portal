using Domain.Services.Job_Seeker.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Seeker.Applications.Interfaces
{
    public interface IJobApplicationService
    {
        Task ApplyJobAsync(Guid jobSeekerId, ApplyJobDto dto);
        Task <List<MyApplicationDto>> GetMyApplicationsAsync(Guid jobSeekerId);
    }
}
