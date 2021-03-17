using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace blogging.Controllers
{
    using Models;
    public class AuthorController : Controller
    {

        // GET: Author

        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BeAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BeAuthor(USER us,string rdFemale,string rdMale)
        {
            if (!string.IsNullOrEmpty(rdFemale))
                us.Gender = true;
            if (!string.IsNullOrEmpty(rdMale))
                us.Gender = true;

            us.Author = true;
            us.Confirmed = false;
            us.Active = true;
            us.RecordDate = DateTime.Now;
            context.USERs.Add(us);

            context.SaveChanges();
            ROLE Author = context.ROLEs.FirstOrDefault(x => x.RoleName == "Author");

            UserRole ur = new UserRole();
            ur.RoleID = Author.RoleID;
            ur.UserRoleID = ur.UserRoleID;

            context.UserRoles.Add(ur);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
            
        }
        public ActionResult MyArticles()
        {
            var data = context.ARTICLEs.Where(x => x.USER.Name == User.Identity.Name).ToList();
            return View(data);
        }
    }
}