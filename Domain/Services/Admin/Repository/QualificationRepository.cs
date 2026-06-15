using Domain.Data;
using Domain.Services.Admin.Interface;
using Microsoft.EntityFrameworkCore;


namespace Domain.Services.Admin.Repository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly AppDbContext _context;

        public QualificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Qualification?> GetQualificationByNameAsync(string name)
        {
            return await _context.Qualifications.FirstOrDefaultAsync
                (x =>
                  x.Name.ToLower() ==
                  name.ToLower()
                );
        }

        public async Task AddQualificationAsync(Models.Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
