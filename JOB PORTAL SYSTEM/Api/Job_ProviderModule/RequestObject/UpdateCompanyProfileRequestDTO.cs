namespace JOB_PORTAL_SYSTEM.Api.Job_ProviderModule.RequestObject
{
    public class UpdateCompanyProfileRequest
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid IndustryId { get; set; }
        public Guid LocationId { get; set; }
    }
}
