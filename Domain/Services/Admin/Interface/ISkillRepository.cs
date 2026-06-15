using Domain.Models;
using Domain.Services.Admin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interface
{
    public interface ISkillRepository
    {
        Task<Skill> AddSkillAsync(AddSkillDto addSkillDto);
        Task<Skill> GetSkillByIdAsync(Guid skillId);
        Task<Skill> UpdateSkillAsync(UpdateSkillDto updateSkillDto);
        Task<Skill> DeleteSkillAsync(Guid Id);
    }
}
