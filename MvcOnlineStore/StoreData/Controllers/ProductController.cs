using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Services;

namespace StoreData.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productservice = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //商品列表
        public ActionResult _ProductListPartial()
        {
            var list = productservice.ProductList();
            return PartialView(list);
        }
        [Route("{ProductId}")]
        //單一商品頁面
        public ActionResult ProductItem(string ProductId)
        {
            return View();
        }
        //側邊分類欄
        public ActionResult CategoriesList()
        {
            return View();
        }
    }
}