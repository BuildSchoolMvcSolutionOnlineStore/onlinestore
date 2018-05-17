using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        //新增訂單
        public ActionResult CreateOrder()
        {
            return View();
        }

        //修改訂單
        public ActionResult UpdateOrder()
        {
            return View();
        }

        //取消訂單
        public ActionResult DeleteOrder()
        {
            return View();
        }
    }
}