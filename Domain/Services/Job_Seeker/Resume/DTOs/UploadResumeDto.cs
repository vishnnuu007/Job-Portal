using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Job_Seeker.Resume.DTOs
{
    public class UploadResumeDto
    {
        public IFormFile File { get; set; } = null!;
    }
}
