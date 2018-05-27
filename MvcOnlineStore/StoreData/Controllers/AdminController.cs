using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;
using StoreData.ViewModels.Manager;

namespace StoreData.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private AdminService adminService = new AdminService();
        // GET: Admin
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Members")]
        public ActionResult Members(string Id,int Page = 1)
        {
            var Data = new MemberView
            {
                Search = Id,
                Paging = new ForPaging(Page)
            };
            Data.DataList = customerService.CustomerList(Data.Search, Data.Paging);
            return View(Data);
        }

        [Route("Products")]
        public ActionResult Products(string Id, int Page = 1)
        {
            var Data = new ProductView
            {
                Search = Id,
                Paging = new ForPaging(Page)
            };
            Data.DataList = adminService.GetProductList(Data.Search, Data.Paging);
            return View(Data);
        }
        [HttpPost]
        public ActionResult UpdateStock(string Id,int stock,string search,int Page)
        {
            productService.UpdateStock(Id, stock);
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products",Id = search ,Page });
        }
    }
}