using AutoMapper;
using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<AddSkillDto> AddSkillAsync(AddSkillDto addSkillDto)
        {
            try
            {
                var skill = await _skillRepository.AddSkillAsync(addSkillDto);
                return _mapper.Map<AddSkillDto>(skill);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<AddSkillDto> GetSkillByIdAsync(Guid skillId)
        {
            try
            {
                var skill = await _skillRepository.GetSkillByIdAsync(skillId);
                return _mapper.Map<AddSkillDto>(skill);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UpdateSkillDto> UpdateSkillAsync(UpdateSkillDto updateSkillDto)
        {
            try
            {
                var skill = await _skillRepository.UpdateSkillAsync(updateSkillDto);
                return _mapper.Map<UpdateSkillDto>(skill);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<DeleteSkillDto> DeleteSkillAsync(Guid skillId)
        {
            try
            {
                var skill = await _skillRepository.DeleteSkillAsync(skillId);
                return _mapper.Map<DeleteSkillDto>(skill);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
