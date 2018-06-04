using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;
using StoreData.ViewModels.Home;
using StoreData.Models;

namespace StoreData.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        private ProductService productservice = new ProductService();
        // GET: Product
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("ProductList")]
        ////商品列表
        public ActionResult ProductList()
        {
            return View();
        }
        //public ActionResult _ProductListPartial()
        //{
        //    var list = productservice.ProductList();
        //    return PartialView(list);
        //}
        [Route("{Id}")]
        //單一商品頁面
        public ActionResult ProductItem(string Id)
        {
            //var Data = new Products();
            //Data = productservice.FindproductById(Data.ProductID);
            //return View(Data);
            var list = productservice.FindproductById(Id);
            return View(list);
        }
        //側邊分類欄
        public ActionResult CategoriesList()
        {
            return View();
        }
    }
}