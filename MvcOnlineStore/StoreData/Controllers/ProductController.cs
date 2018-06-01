using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;

namespace StoreData.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        private ProductService productservice = new ProductService();
        //// GET: Product
        //[Route("")]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        ////商品列表
        [Route("ProductList")]
        public ActionResult ProductList()
        {
            return View();
        }
        //public ActionResult _ProductListPartial()
        //{
        //    var list = productservice.ProductList();
        //    return PartialView(list);
        //}
        //[Route("{Id}")]
        ////單一商品頁面
        //public ActionResult ProductItem(string Id)
        //{
        //    var item = productservice.FIndById(Id);
        //    return View(item);
        //}
        //側邊分類欄
        public ActionResult CategoriesList()
        {
            return View();
        }
    }
}