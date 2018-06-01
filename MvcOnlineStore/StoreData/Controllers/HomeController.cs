using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Repositories;

namespace StoreData.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private ProductsRepository productservice = new ProductsRepository();
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("About")]
        public ActionResult About()
        {
            return View();
        }
        [Route("MailUS")]
        public ActionResult MailUS()
        {

            return View();
        }
        public ActionResult _NavPartial()
        {
            return PartialView();
        }
    }
}