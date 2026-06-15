using Domain.Data;
using Domain.Models;
using Domain.Services.Member.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyMember> CreateAsync(CompanyMember member)
        {
            await _context.CompanyMembers.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<CompanyMember?> GetByIdAsync(Guid id)
        {
            return await _context.CompanyMembers.FindAsync(id);

        }

        public async Task<List<CompanyMember>> GetAllAsync()
        {
            return await _context.CompanyMembers.ToListAsync();
        }

        public async Task<CompanyMember> UpdateAsync(CompanyMember member)
        {
            _context.CompanyMembers.Update(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var member = await _context.CompanyMembers.FindAsync(id);

            if (member == null)
                return false;

            _context.CompanyMembers.Remove(member);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}




