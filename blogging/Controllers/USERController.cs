
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using blogging.Models;

namespace blogging.Controllers
{
    public class USERController : Controller
    {
        // GET: USER

        BlogContext context = new BlogContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(USER us) //   us :means user
        {
            string user = ValidateUser(us.UserName, us.Password);

            if (!string.IsNullOrEmpty(user))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, us.UserName,
                    DateTime.Now, DateTime.Now.AddMinutes(15), true,
                    user, FormsAuthentication.FormsCookiePath);
                
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);

                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;

                }

                Response.Cookies.Add(ck);


                FormsAuthentication.RedirectFromLoginPage(us.UserName, true);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("LogIn");

        }

        string ValidateUser(string un, string pwd)
        {
            USER us = context.USERs.FirstOrDefault(x => x.UserName == un && x.Password == pwd);

            if (us != null)
            {
                return us.UserName;
            }

            else
            {

                return "";


            }


        }
        public ActionResult Logout(string RedirectUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(RedirectUrl);
        }


        public ActionResult SignIn()
        {

            return View();
        
     
        }

        [HttpPost]
        public ActionResult SignIn (USER un,string rdFemale,string rdMale)
        {
            if (!string.IsNullOrEmpty(rdFemale))
                un.Gender = true;
            if (!string.IsNullOrEmpty(rdMale))
                un.Gender = false;

            un.Author = false;
            un.Confirmed = true;
            un.Active = true;
            un.Birthdate = un.Birthdate.Value.Date;
            un.RecordDate = DateTime.Now;

            context.USERs.Add(un);
            context.SaveChanges();
            return RedirectToAction("LogIn");

        
        }



    }
    
}