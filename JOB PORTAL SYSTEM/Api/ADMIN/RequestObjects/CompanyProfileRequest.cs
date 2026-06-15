namespace JOB_PORTAL_SYSTEM.Api.ADMIN.RequestObjects
{
    public class CompanyProfileRequest
    {
        public Guid Id { get; set; }
        public Guid IndustryId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
