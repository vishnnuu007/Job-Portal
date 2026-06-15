using Domain.Services.Member.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Interface
{
    public interface IMemberService
    {
        Task<MemberResponseDto> CreateAsync(CreateMemberDto dto);
        Task<MemberResponseDto?> GetByIdAsync(Guid id);
        Task<List<MemberResponseDto>> GetAllAsync();

        Task<MemberResponseDto> UpdateAsync(Guid id, UpdateCompanyMemberDto dto);

        Task<bool> DeleteAsync(Guid id);
    }
}
