using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Repositories;

namespace StoreData.Controllers
{
    public class HomeController : Controller
    {
        private ProductsRepository productservice = new ProductsRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult _NavPartial()
        {
            return PartialView();
        }
    }
}