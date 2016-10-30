using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace BugTracker.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserRoleAssignHelper userRole = new UserRoleAssignHelper();

        // GET: Admin
        public ActionResult Index()
        {
            var model = db.Users.ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        //GET: Admin/SelectRole/5
        public ActionResult EditUser(string id)
        {
            var user = db.Users.Find(id);
            AdminUserViewModel AdminModel = new AdminUserViewModel();
            var selected = userRole.ListUserRoles(id);
            AdminModel.Roles = new MultiSelectList(db.Roles, "Name", "Name", selected);
            AdminModel.User = user;

            return View(AdminModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditUser(AdminUserViewModel model)
        {
            var user = db.Users.Find(model.User.Id);
            foreach (var rolermv in db.Roles.Select(r => r.Id).ToList())
            {
                userRole.RemoveUserFromRole(user.Id, rolermv);
            }

            foreach (var roleadd in model.SelectedRoles)
            {
                userRole.AddUserToRole(user.Id, roleadd);
            }
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin, ProjectManager")]
        //GET: Admin/SelectProject/5
        public ActionResult ProjectUser(string id)
        {
            var user = db.Users.Find(id);
            AdminProjectUserAssignViewModel AdminProjectModel = new AdminProjectUserAssignViewModel();
            AdminProjectModel.Users = new MultiSelectList(db.Users, "Name", "Name", selected);
            AdminProjectModel.User = user;
                {
                return View(AdminProjectModel);
            }
        }

        [Authorize(Roles = "Admin, ProjectManager")]
        [HttpPost]
        public ActionResult ProjectUser(AdminProjectUserAssignViewModel model)
         {
            db.Users.Attach(User);
            foreach (var useradd in db.Users.Select(u => u.Id).ToList())
                {
                    Project.users.Add(User);
                }

                foreach (var userrmv in model.SelectedUsers)
                {
                    Project.users.Remove(User);
                }
              db.SaveChanges();
                return RedirectToAction("ProjectUser", "Admin");
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
