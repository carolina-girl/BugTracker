using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Models
{
    public class Project
    {
        internal static object users;

        public Project()
            {
                this.Users = new HashSet<ApplicationUser>();
                this.Tickets = new HashSet<Tickets>();
            }
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTimeOffset Created { get; set; }
            public DateTimeOffset? Updated { get; set; }
            public string Body { get; set; }

            public virtual ICollection<ApplicationUser> Users { get; set; }
            public virtual ICollection<Tickets> Tickets { get; set; }

    }
    }
