using AutoMapper;
using Domain.Models;
using Domain.Services.Job_Provider.Candidate.Dto;
using Domain.Services.Job_Provider.Candidate.Interface;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Candidate
{
    public class CandidateService:ICandidateService 
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService (ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
      
        }

        public async Task<List<CandidateDto>> FilterCandidatesAsync(CandidateFilterRequest request)
        {
            var candidates = await _candidateRepository.FilterCandidatesAsync(request.Skill);

            return _mapper.Map<List<CandidateDto>>(candidates);
        }

    }
}
