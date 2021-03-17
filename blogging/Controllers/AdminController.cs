using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogging.Controllers
{

    using Models;
    public class AdminController : Controller
    {
        // GET: Admin
        BlogContext context = new BlogContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AuthorConfirms()
        {
            var data = context.USERs.Where(x => x.Author == true && x.Confirmed == false).ToList();

            return View(data);
        }

        public ActionResult Confirm(int UserID)
        {

            USER un = context.USERs.FirstOrDefault(x => x.UserID == UserID);

            un.Confirmed = true;

            context.SaveChanges();

            return RedirectToAction("AuthorConfirms");

        }
    }

    
}