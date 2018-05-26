using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;

namespace StoreData.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        // GET: Admin
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Members")]
        public ActionResult Members(string Id)
        {
            var list = customerService.CustomerList(Id);
            return View(list);
        }

        [Route("Prodcts")]
        public ActionResult Prodcts()
        {
            return View();
        }
    }
}