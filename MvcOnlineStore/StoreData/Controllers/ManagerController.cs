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
        private CustomerService customerservice = new CustomerService();
        private OrdersService ordersservice = new OrdersService();
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
        public ActionResult ManagementCustomer()
        {
            var list = customerservice.CustomerList();
            return PartialView(list);
        }

        //訂單列表
        public ActionResult ManagementOrders()
        {
            var list = ordersservice.OrdersList();
            return PartialView(list);
        }
    }
}