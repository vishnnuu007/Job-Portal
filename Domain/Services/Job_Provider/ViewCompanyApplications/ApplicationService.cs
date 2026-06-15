using AutoMapper;
using Domain.Services.Job_Provider.ViewCompanyApplications.Dto;
using Domain.Services.Job_Provider.ViewCompanyApplications.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewCompanyApplications
{
    public class ApplicationService:IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService (IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public async Task<List<CompanyApplicationDto>> GetApplicationsByCompanyAsync(Guid companyId)
        {
            var applications = await _applicationRepository
                .GetApplicationsByCompanyAsync(companyId);

            return _mapper.Map<List<CompanyApplicationDto>>(applications);
        }
    }
}
