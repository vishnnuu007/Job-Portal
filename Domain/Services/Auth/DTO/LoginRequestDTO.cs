using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth.DTO
{
    public class LoginrequestDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
