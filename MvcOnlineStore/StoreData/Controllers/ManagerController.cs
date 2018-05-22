using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;
using StoreData.ViewModels.Manager;

namespace StoreData.Controllers
{
    public class ManagerController : Controller
    {
        private ProductService productservice = new ProductService();
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
        [HttpPost]
        public ActionResult SingIn(SingInViewModel model)
        {
            return RedirectToAction("Management");
        }
        //管理主頁面
        public ActionResult Management()
        {
            return View();
        }
        //產品列表
        public ActionResult ManagementProduct()
        {
            var list = productservice.ProductList();
            return PartialView(list);
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