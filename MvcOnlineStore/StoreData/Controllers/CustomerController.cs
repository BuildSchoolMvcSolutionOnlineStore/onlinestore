using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        //客戶登入
        public ActionResult SingIn()
        {
            return View();
        }
        
        //新增客戶資料
        public ActionResult CreateCustomer()
        {
            return View();
        }

        //修改客戶資料
        public ActionResult UpdateCustomer()
        {
            return View();
        }
    }
}