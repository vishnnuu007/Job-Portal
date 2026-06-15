using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Services.Auth.DTO
{
    public class LoginDTO
    {
        public Guid Id { get; set; }

        public Guid? JobSeekerId { get; set; }

        public Guid? JobProviderId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string Token { get; set; }

       
    }
}
