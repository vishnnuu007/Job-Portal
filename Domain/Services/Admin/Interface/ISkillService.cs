using Domain.Services.Admin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interface
{
    public interface ISkillService
    {
        Task<AddSkillDto> AddSkillAsync(AddSkillDto addSkillDto);
         Task<AddSkillDto> GetSkillByIdAsync(Guid skillId);
        Task<UpdateSkillDto> UpdateSkillAsync(UpdateSkillDto updateSkillDto);
        Task<DeleteSkillDto> DeleteSkillAsync(Guid Id);
    }
}
