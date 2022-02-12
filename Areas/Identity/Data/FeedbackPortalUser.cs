using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FeedbackPortal.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FeedbackPortalUser class
    public class FeedbackPortalUser : IdentityUser
    {
        public int? ClientId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
