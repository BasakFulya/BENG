using blogging.Models;
using System.Linq;
using System.Web.Mvc;

namespace blogging.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        BlogContext context = new BlogContext();
        public ActionResult Index(int ID)
        {
            return View(ID);
        }

        public PartialViewResult CategoryWidget()
        {
            return PartialView(context.CATEGORies.ToList());
        }


        public ActionResult ArticleList(int ID)
        {

            var data = context.ARTICLEs.Where(x => x.CategoryID == ID).ToList();

            return View("ArticleListWidget", data);

        }

    }
}