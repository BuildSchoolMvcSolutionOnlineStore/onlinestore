using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //新增產品
        public ActionResult CreateProduct()
        {
            return View();
        }

        //修改產品
        public ActionResult UpdateProduct()
        {
            return View();
        }

        //刪除產品
        public ActionResult DeleteProduct()
        {
            return View();
        }
        //商品列表
        public ActionResult ProductList()
        {
            var repository = new ProductsRepository();
            var list = repository.GetAllProducts();
            return View(list);
        }
        //單一商品頁面
        public ActionResult ProductItem()
        {
            return View();
        }
    }
}