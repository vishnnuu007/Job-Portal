using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Interface
{
    public interface IApplicationRepository
    {
        Task<JobApplication> GetByIdAsync(Guid id);

        Task<JobApplication> UpdateAsync(JobApplication application);
    }
}
