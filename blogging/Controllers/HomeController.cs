using blogging.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System;


namespace blogging.Controllers
{
    using Models;
    public class HomeController : Controller
    {
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult ArticleList()
        {
            var data = context.ARTICLEs.ToList();
            return View("ArticleListWidget", data);



        }

        public PartialViewResult PopularArticlesWidget()
        {
            var model = context.ARTICLEs.OrderByDescending(x => x.UploadDate).Take(3).ToList();
            return PartialView(model);
        }
    }
}