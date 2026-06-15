using Domain.Models;

namespace Domain.Services.Jobs.DTOs
{
    public class GetJobsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Location {  get; set; } = null!;
        public int Salary { get; set; }

        public string PostedBy { get; set; } = null!; // Company member name
        public CompanyMember Role { get; set; }
    }
}
