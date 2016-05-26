using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.DBDal;

namespace Taskmvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowOrderList()
        {
            MyDal result = new MyDal();
            var model = result.ShowOrders();
            return View(model);
        }

        public ActionResult ShowDetailsList(int id)
        {
            MyDal result = new MyDal();
            var model = result.GetById(id);
            return View(model);
        }

        public ActionResult AddNewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckAddNewOrder(DAL.Entities.Order value)
        {
            MyDal result = new MyDal();
            var model = result.AddOrder(value);
            return View(model);

        }
    }
}