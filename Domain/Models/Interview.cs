using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Interview
    {
        public Guid Id { get; set; }
        [ForeignKey("Application")]
        public Guid ApplicationId { get; set; }
        public JobApplication Application { get; set; }
        public DateTime InterviewDate { get; set; }
        public InterviewMode Mode { get; set; }
        public InterviewStatus Status { get; set; }
    }
}
