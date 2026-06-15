using Domain.Services.Job_Provider.Candidate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Services.Job_Provider.Candidate.Interface
{
    public interface ICandidateService
    {
        Task<List<CandidateDto>> FilterCandidatesAsync(CandidateFilterRequest request);

    }
}
