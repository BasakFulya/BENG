using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogging.Controllers
{
    using Models;
    using blogging.Appp_Classes;
    using System.Drawing;
    [Authorize]
    public class ArticleController : Controller
    {
        // GET: Article
        BlogContext context = new BlogContext();

        public object Settings { get; private set; }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Detail(int ID)
        {

            var data = context.ARTICLEs.FirstOrDefault(x => x.ArticleID == ID);
            return View(data);


        }

        [Authorize(Roles = "Admin,Author")]
        public ActionResult AddArticle()
        {
            ViewBag.Categories = context.CATEGORies.ToList();
            return View();

        }
        [HttpPost]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult AddArticle(ARTICLE article, HttpPostedFileBase picture)
        {
            Image img = Image.FromStream(picture.InputStream);
            Bitmap smallPicture = new Bitmap(img, Setting.ImgSmallSize);
            Bitmap mediumPicture = new Bitmap(img, Setting.ImgMiddleSize);
            Bitmap largePicture = new Bitmap(img, Setting.ImgLargeSize);
            smallPicture.Save(Server.MapPath("/Content/ArticlePicture/SmallSize/" + picture.FileName));
            mediumPicture.Save(Server.MapPath("/Content/ArticlePicture/MiddleSize/" + picture.FileName));
            largePicture.Save(Server.MapPath("/Content/ArticlePicture/LargeSize/" + picture.FileName));
            PICTURE pcture = new PICTURE();
            pcture.LargeSize = "/Content/ArticlePicture/SmallSize/" + picture.FileName;
            pcture.MiddleSize = "/Content/ArticlePicture/MiddleSize/" + picture.FileName;
            pcture.SmallSize = "/Content/ArticlePicture/LargeSize/" + picture.FileName;
            context.PICTUREs.Add(pcture);
            context.SaveChanges();

            article.PictureID = pcture.PictureID;
            article.UploadDate = DateTime.Now;
            article.ViewedNumber = 0;
            article.ArticleLike = 0;
            int writerid = context.USERs.FirstOrDefault(x => x.UserName == User.Identity.Name).UserID;
            article.AuthorID = writerid;
            context.ARTICLEs.Add(article);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        [AllowAnonymous]
        public string like(int id)
        {
            ARTICLE aRTICLE = context.ARTICLEs.FirstOrDefault(x => x.ArticleID == id);
            aRTICLE.ArticleLike++;
            context.SaveChanges();
            return aRTICLE.ArticleLike.ToString();
        }

   
    }
}