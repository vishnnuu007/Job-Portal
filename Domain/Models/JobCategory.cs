using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
