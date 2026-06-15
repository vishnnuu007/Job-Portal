using Domain.Data;
using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Admin.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddLocationAsync(AddLocationDto dto)
        {
            try
            {
                var existingLocation = await _context.Locations.FirstOrDefaultAsync
                    (x =>x.Name.ToLower() == dto.Name.ToLower());

                if (existingLocation != null)
                {
                    return "Location Already Exists";
                }

                var location = new Models.Location
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name
                };

                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();

                return "Location Added Successfully";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }
    }
}