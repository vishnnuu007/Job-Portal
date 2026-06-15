using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Qualification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<JobSeekerProfile> jobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();

        

    }
}
