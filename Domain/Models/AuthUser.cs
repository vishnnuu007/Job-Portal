using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AuthUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<JobSeeker> JobSeekers { get; set; } = new List<JobSeeker>();
        public ICollection<JobProvider> JobProviders { get; set; } = new List<JobProvider>();
    }
}
