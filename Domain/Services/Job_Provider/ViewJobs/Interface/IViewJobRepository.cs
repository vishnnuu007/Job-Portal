using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewJobs.Interface
{
    public interface IViewJobRepository
    {
        Task<List<Job>> ViewJobsByCompanyIdAsync(Guid companyId);
    }
}
