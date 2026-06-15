using Domain.Models;
using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Job_Provider.ViewJobs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewJobs.Interface
{
    public interface IViewJobService
    {
        Task<List<ViewCompanyJobDto>> ViewJobsByCompanyIdAsync(Guid companyId);
    }
}
