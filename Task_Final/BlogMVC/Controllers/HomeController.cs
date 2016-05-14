using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        BlogDAL.DBDAL.DAL myDal = new BlogDAL.DBDAL.DAL();

        public ActionResult Index()
        {            
            return View(myDal.ShowBlogs());
        }

        public ActionResult Blog()
        {
            var model = myDal.GetBlogByName(RouteData.Values["id"].ToString());
            return View(model);
        }

        public ActionResult FindByTag()
        {
            return View();
        }

        public ActionResult AddBlogNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlogNewUser(BlogDAL.Entities.Blog blog)
        {
            bool check = myDal.AddDocument(blog, User.Identity.Name.Replace(" ", ""));
            if (check)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Введены неверные данные";
            return View(blog);
        }

    }
}