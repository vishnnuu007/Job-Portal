using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Industry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
