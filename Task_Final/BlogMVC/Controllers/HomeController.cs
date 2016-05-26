﻿using System;
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

        [HttpPost]
        public ActionResult FindByTag(BlogDAL.Entities.Blog blog)
        {
            if (!string.IsNullOrEmpty(blog.Tag))
            {
                return View("ShowBlogsByTag", myDal.GetBlogByTag(blog.Tag));
            }
            ViewBag.Error = "Данные были введены некорректно, проверьте заполнение всех полей.";
            return View();
        }

        public ActionResult FindByText()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindByText(BlogDAL.Entities.Blog blog)
        {
            if (!string.IsNullOrEmpty(blog.Document))
            {
                return View("ShowBlogsByTag", myDal.GetBlogByText(blog.Document));
            }
            ViewBag.Error = "Данные были введены некорректно, проверьте заполнение всех полей.";
            return View();
        }

        [HttpPost]
        public ActionResult ShowBlogsByTag(IEnumerable<BlogDAL.Entities.Blog> blogs)
        {
            return View(blogs);
        }

        public ActionResult AddBlogNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlogNewUser(BlogDAL.Entities.Blog blog)
        {
            if (!string.IsNullOrEmpty(blog.Document) && !string.IsNullOrEmpty(blog.Tag))
            {
                bool check = myDal.AddDocument(blog, User.Identity.Name.Replace(" ", ""));
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Не все данные были введены некорректно, проверьте заполнение всех полей.";
            return View(blog);
        }

        public ActionResult Comment()
        {
            return View(myDal.ShowComment(RouteData.Values["id"].ToString()));
        }

        [Authorize]
        public ActionResult AddNewComment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddNewComment(BlogDAL.Entities.Comment comment)
        {
            if (!string.IsNullOrEmpty(comment.CommentText))
            {
                comment.BlogID = int.Parse(RouteData.Values["id"].ToString());
                bool check = myDal.AddComment(comment, User.Identity.Name.Replace(" ", ""));
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Не все данные были введены корректно, проверьте заполнение всех полей.";
            return View(comment);
        }

    }
}