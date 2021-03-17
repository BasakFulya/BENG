using blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogging.Controllers
{

    public class TagController : Controller
    {
        // GET: /Tag/
        BlogContext blogging = new BlogContext();

        public ActionResult Index(int ID)
        {
            return View(ID);
        }
        public PartialViewResult TagsWidget()
        {
            return PartialView(blogging.TAGs.ToList());
        }

        public ActionResult ArticleList(int ID)
        {

            var data = blogging.ARTICLEs.Where(x => x.TAGs.Any(y => y.TagID == ID)).ToList();


            return View("ArticleListWidget", data);

        }
    }
}