using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Interface
{
    public interface IMemberRepository
    {
        Task<CompanyMember> CreateAsync(CompanyMember member);
        Task<CompanyMember?> GetByIdAsync(Guid id);
        Task<List<CompanyMember>> GetAllAsync();

        Task<CompanyMember> UpdateAsync(CompanyMember member);
        Task<bool> DeleteAsync(Guid id);
    }
}
