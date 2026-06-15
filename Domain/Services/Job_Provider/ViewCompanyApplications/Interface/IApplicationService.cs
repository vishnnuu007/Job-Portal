using Domain.Services.Job_Provider.ViewCompanyApplications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewCompanyApplications.Interface
{
    public interface IApplicationService
    {
        Task<List<CompanyApplicationDto>> GetApplicationsByCompanyAsync(Guid companyId);
    }
}
