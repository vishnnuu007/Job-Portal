using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CompanyMember
    {
        public Guid Id { get; set; }
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } // Foreign key to Company
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CompanyRole Role { get; set; } // Enum for Company roles (e.g., HR, Recruiter, Manager)

        public ICollection<Job> Jobs { get; set; } = new List<Job>(); // Navigation property for related jobs

    }
}
