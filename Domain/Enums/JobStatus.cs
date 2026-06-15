using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum JobStatus
    {
        Created,    // Just created, not yet submitted for approval
        Pending,    // Submitted, awaiting approval
        Active,     // Approved and live
        Verified,  // Verified by admin (optional step)
        Closed,     // No longer accepting applications
     }
}
