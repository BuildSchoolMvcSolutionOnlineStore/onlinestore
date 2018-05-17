using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        //管理者登入
        public ActionResult SingIn()
        {
            return View();
        }
        
        //產品列表
        public ActionResult ProductList()
        {
            return View();
        }
        
        //客戶列表
        public ActionResult CustomerList()
        {
            return View();
        }

        //訂單列表
        public ActionResult OrderList()
        {
            return View();
        }
    }
}