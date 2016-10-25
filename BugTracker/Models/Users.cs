using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Users
    {
        public class ApplicationUser : IdentityUser
        {
            public ApplicationUser()
            {
                this.Projects = new HashSet();
            }

            public virtual ICollection Projects { get; set; }
        }
    }
}