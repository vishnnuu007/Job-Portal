using AutoMapper;
using Domain.Services.Job_Provider.Job_Service.DTO;
using Domain.Services.Job_Provider.ViewJobs.Dto;
using Domain.Services.Job_Provider.ViewJobs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.ViewJobs
{
    public class ViewJobService:IViewJobService
    {
        private readonly IViewJobRepository _viewJobRepository;
        private readonly IMapper _mapper;

        public ViewJobService (IViewJobRepository viewJobRepository, IMapper mapper )
        {
            _viewJobRepository = viewJobRepository;
            _mapper = mapper;
        }
        public async Task<List<ViewCompanyJobDto>> ViewJobsByCompanyIdAsync(Guid companyId)
        {
            var jobs = await _viewJobRepository .ViewJobsByCompanyIdAsync(companyId);
            return _mapper.Map <List<ViewCompanyJobDto>> (jobs);
        }
    }
}
