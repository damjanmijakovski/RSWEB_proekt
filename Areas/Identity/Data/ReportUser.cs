using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Report.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FeedbackPortalUser class
    public class ReportUser : IdentityUser
    {
        public int? ClientId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
