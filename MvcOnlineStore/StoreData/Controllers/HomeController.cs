using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Repositories;
using StoreData.Services;
using StoreData.ViewModels.Home;

namespace StoreData.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private ProductService productservice = new ProductService();
        public ActionResult Index()
        {
            var list = new HomeIndexTop();
            list.ProductsList = productservice.GetProductsListBYThree();
            list.MidProductsList = productservice.GetProductsListBYFour();
            list.DownProductsList = productservice.GetProductsListBYSix();
            return View(list);
        }
        [Route("About")]
        public ActionResult About()
        {
            var list = new HomeIndexTop();
            return View(list);
        }
        [Route("MailUS")]
        public ActionResult MailUS()
        {
            var list = new HomeIndexTop();
            return View(list);
        }
        public ActionResult _NavPartial()
        {
            return PartialView();
        }
    }
}