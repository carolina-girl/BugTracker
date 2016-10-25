using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Projects
    {
            public Project()
            {
                this.Users = new HashSet();
            }

            public virtual ICollection Users { get; set; }
        }

    }
}