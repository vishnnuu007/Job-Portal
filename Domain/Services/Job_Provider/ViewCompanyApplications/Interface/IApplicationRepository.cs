using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewCompanyApplications.Interface
{
    public interface IApplicationRepository
    {
        Task<List<JobApplication>> GetApplicationsByCompanyAsync(Guid companyId);
    }
}
