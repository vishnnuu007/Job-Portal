using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;

namespace Domain.Services.Admin.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;

        public QualificationService(IQualificationRepository qualificationRepository)
        {
            _qualificationRepository = qualificationRepository;
        }

        public async Task<string>AddQualificationAsync(AddQualificationDto dto)
        {
            try
            {
                var existingQualification = await _qualificationRepository.GetQualificationByNameAsync(dto.Name);

                if (existingQualification != null)
                {
                    return "Qualification Already Exists";
                }

                var qualification = new Models.Qualification
                {
                        Id = Guid.NewGuid(),
                        Name = dto.Name,
                        Description = dto.Description
                };

                await _qualificationRepository.AddQualificationAsync(qualification);
                await _qualificationRepository.SaveChangesAsync();
                return "Qualification Added Successfully";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }
    }
}