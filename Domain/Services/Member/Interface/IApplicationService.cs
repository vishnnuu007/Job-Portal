using Domain.Models;
using Domain.Services.Member.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Member.Interface
{
    public interface IApplicationservice
    {
        Task<JobApplication> UpdateStatusAsync(Guid id, UpdateApplicationStatus dto);

    }
}
