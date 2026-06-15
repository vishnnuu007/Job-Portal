
namespace Domain.Services.Job_Provider.CompanyProfile.DTO
{
    public class CreateCompanyProfileRequest
    { 
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public Guid IndustryId { get; set; }
        public Guid LocationId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
