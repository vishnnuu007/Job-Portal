using Domain.Data;
using Domain.Models;
using Domain.Services.Job_Provider.Interviews.Dto;
using Domain.Services.Job_Provider.Interviews.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Job_Provider.Interviews
{
    public class InterviewRepository:IInterviewRepository 
    {
        private readonly AppDbContext _context;

        public InterviewRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ScheduleInterviewAsync(Interview interview)
        {
            interview.Id = Guid.NewGuid();
            var user = await _context.JobApplications.FirstOrDefaultAsync(a => a.Id == interview.ApplicationId);
            if (user == null)
            {
                return false;
            }
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Interview>> GetInterviewsAsync(Guid companyId)
        {
            return await _context.Interviews.Include(i => i.Application).
                ThenInclude(a => a.Job).
                Where(i => i.Application.Job.CompanyId == companyId).
                ToListAsync();
        }

        public async Task<Interview> GetInterviewByIdAsync(Guid interviewId)
        {
            return await _context.Interviews.Include(i => i.Application).ThenInclude(a => a.Job).FirstOrDefaultAsync(i => i.Id == interviewId);
        }
        public async Task<InterviewResponseDto> UpdateInterviewAsync(UpdateInterviewDto updateInterview)
        {
            var existingInterview = await _context.Interviews.FirstOrDefaultAsync(i => i.Id == updateInterview.Id);

            if (existingInterview == null)
            {
                throw new InvalidOperationException
                (
                    $"Interview with Id {updateInterview.Id} does not exist."
                );
            }

            existingInterview.InterviewDate = updateInterview.InterviewDate;

            existingInterview.Mode = updateInterview.Mode;

            existingInterview.Status = updateInterview.Status;

            await _context.SaveChangesAsync();

            return new InterviewResponseDto
            {
                Id = existingInterview.Id,
                ApplicationId = existingInterview.ApplicationId,
                InterviewDate = existingInterview.InterviewDate,
                Mode = existingInterview.Mode,
                Status = existingInterview.Status
            };
        }
        public async Task<bool> DeleteInterviewAsync(Guid interviewId)
        {

            var interview = await _context.Interviews.FindAsync(interviewId);

            if (interview == null)
            {
                return false;
            }

            _context.Interviews.Remove(interview);

            await _context.SaveChangesAsync();

            return true;


        }
    }
}
