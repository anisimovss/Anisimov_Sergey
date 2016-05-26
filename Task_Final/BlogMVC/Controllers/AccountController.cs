using BlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogMVC.Controllers
{
    public class AccountController : Controller
    {
        BlogDAL.DBDAL.DAL myDal = new BlogDAL.DBDAL.DAL();

        public ActionResult LogInNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogInNewUser(UserPasswordViewModel userAndPassword)
        {
            if (myDal.LoginInSystem(userAndPassword.User,userAndPassword.Password) && !string.IsNullOrEmpty(userAndPassword.User) 
                && !string.IsNullOrEmpty(userAndPassword.Password))
            {
                FormsAuthentication.SetAuthCookie(userAndPassword.User, false);
                ViewBag.LoginUser = "Пользователь вошел в систему";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Введены неверные данные, проверьте заполнение всех полей.";
            return View(userAndPassword);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(BlogDAL.Entities.User myNewUser)
        {
            if (myDal.CheckAddUser(myNewUser.Login) && !string.IsNullOrEmpty(myNewUser.Login)
                && !string.IsNullOrEmpty(myNewUser.Password))
            {
                myDal.AddUser(myNewUser);
                ViewBag.RegistrationUser = "Пользователь успешно зарегистрирован";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Такой пользователь уже существует или данные были введены некорректно, проверьте заполнение всех полей.";
            return View(myNewUser);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}