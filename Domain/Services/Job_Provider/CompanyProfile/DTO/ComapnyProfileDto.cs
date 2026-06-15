
namespace Domain.Services.Job_Provider.CompanyProfile.DTO
{
    public class CompanyProfileDto
    {
        public Guid ProviderId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IndustryName { get; set; }
        public string LocationName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
