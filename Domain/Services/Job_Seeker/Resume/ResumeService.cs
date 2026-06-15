using Domain.Services.Job_Seeker.Resume.DTOs;
using Domain.Services.Job_Seeker.Resume.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Job_Seeker.Resume
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _repo;

        public ResumeService(IResumeRepository repo)
        {
            _repo = repo;
        }

        public async Task UploadResumeAsync(Guid jobSeekerId, UploadResumeDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                throw new Exception("File is required");

            // ✔ Validate file type
            var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
            var extension = Path.GetExtension(dto.File.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Invalid file format");

            // ✔ Create folder
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resumes");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // ✔ Unique file name
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, fileName);

            // ✔ Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            // ✔ Check existing resume
            var existing = await _repo.GetByJobSeekerIdAsync(jobSeekerId);

            if (existing == null)
            {
                var resume = new Domain.Models.Resume
                {
                    Id = Guid.NewGuid(),
                    JobSeekerId = jobSeekerId,
                    FileName = dto.File.FileName,
                    FilePath = fileName
                };

                await _repo.AddAsync(resume);
            }
            else
            {
                existing.FileName = dto.File.FileName;
                existing.FilePath = fileName;

                await _repo.UpdateAsync(existing);
            }
        }
    }
}
