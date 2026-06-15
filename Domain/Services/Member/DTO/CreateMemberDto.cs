using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.DTO
{
    public class CreateMemberDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CompanyRole Role { get; set; }
    }
}
