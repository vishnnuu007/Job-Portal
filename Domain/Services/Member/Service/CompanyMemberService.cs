using Domain.Models;
using Domain.Services.Member.DTO;
using Domain.Services.Member.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Service
{
    public class CompanyMemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public CompanyMemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<MemberResponseDto> CreateAsync(CreateMemberDto dto)
        {
            var entity = new CompanyMember
            {
                Id = Guid.NewGuid(),
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role
            };

            var result = await _repository.CreateAsync(entity);

            return new MemberResponseDto
            {
                Id = result.Id,
                CompanyId = result.CompanyId,
                Name = result.Name,
                Email = result.Email,
                Role = result.Role
            };
        }

        public async Task<MemberResponseDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) return null;

            return new MemberResponseDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Email = entity.Email,
                Role = entity.Role
            };
        }

        public async Task<List<MemberResponseDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();

            return list.Select(x => new MemberResponseDto
            {
                Id = x.Id,
                CompanyId = x.CompanyId,
                Name = x.Name,
                Email = x.Email,
                Role = x.Role
            }).ToList();
        }

        public async Task<MemberResponseDto> UpdateAsync(Guid id, UpdateCompanyMemberDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Role = dto.Role;

            var updated = await _repository.UpdateAsync(entity);

            return new MemberResponseDto
            {
                Id = updated.Id,
                CompanyId = updated.CompanyId,
                Name = updated.Name,
                Email = updated.Email,
                Role = updated.Role
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}