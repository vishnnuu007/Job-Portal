using Domain.Services.Admin.Dto;

namespace Domain.Services.Admin.Interface
{
    public interface ILocationRepository
    {
        Task<string> AddLocationAsync(AddLocationDto dto);

    }
}
