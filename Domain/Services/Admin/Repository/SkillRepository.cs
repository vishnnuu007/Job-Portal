using Domain.Data;
using Domain.Models;
using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;
        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Skill> AddSkillAsync(AddSkillDto addSkillDto)
        {
            try
            {
                var skill = new Skill
                {
                    Id = addSkillDto.Id,
                    Name = addSkillDto.Name
                };
                _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding skill: {ex.Message}");
            }
        }

        public async Task<Skill> GetSkillByIdAsync(Guid skillId)
        {
            return await _context.Skills.FindAsync(skillId);
        }
        public async Task<Skill> UpdateSkillAsync(UpdateSkillDto updateSkillDto)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(updateSkillDto.Id);
                if (skill == null)
                {
                    throw new Exception("Skill not found");
                }
                skill.Name = updateSkillDto.Name;
                _context.Skills.Update(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Skill> DeleteSkillAsync(Guid skillId)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(skillId);
                if (skill == null)
                {
                    throw new Exception("Skill not found");
                }
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
