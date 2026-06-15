using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Seeker.Interviews.Interfaces
{
    public interface IInterviewRepository
    {
        Task<List<Interview>> GetByJobSeekerIdAsync(Guid jobSeekerId);
    }
}
