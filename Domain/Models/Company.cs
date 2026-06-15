using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        [ForeignKey("JobProvider")]
        public Guid? ProviderId { get; set; }
        public JobProvider? JobProvider { get; set; }
        public Guid? IndustryId { get; set; }
        public Industry? Industry { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVerified { get; set; }
        public ICollection<CompanyMember> Members { get; set; } = new List<CompanyMember>();
        public ICollection<Job> Jobs { get; set; } = new List<Job>();



    }
}
