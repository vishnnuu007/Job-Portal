using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class JobProvider
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public AuthUser? User { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
