using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interface
{
    public interface IQualificationRepository
    {
        Task<Models.Qualification?> GetQualificationByNameAsync(string name);
        Task AddQualificationAsync(Models.Qualification qualification);
        Task SaveChangesAsync();
    }
}
