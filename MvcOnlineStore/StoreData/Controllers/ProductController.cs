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
        private CategoryService categoryservice = new CategoryService();
        // GET: Product
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        ////商品列表
        [Route("ProductList")]
        public ActionResult ProductList(string ProductName, string sormet, int Page = 1)
        {
            //ViewBag.low = sortOrder = "low";
            //ViewBag.high = sortOrder = "high";
            var list = new HomeIndexTop
            {
                Search = ProductName,
                Paging = new ForPaging(Page)
            };
            switch (sormet)
            {
                case "low":
                    list.GetAllProductsList = productservice.GetSearchProductName(list.Search, list.Paging).OrderBy(x=>x.UnitPrice);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
                case "high":
                    list.GetAllProductsList = productservice.GetSearchProductName(list.Search, list.Paging).OrderByDescending(x=>x.UnitPrice);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
                default:
                    list.GetAllProductsList = productservice.GetSearchProductName(list.Search, list.Paging);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
            }
            return View(list);
        }
        ////商品列表內的商品
        [Route("ProductListBYCategories/{Id}")]
        public ActionResult ProductListBYCategories(int Id, string sormet,int Page = 1)
        {
            var list = new HomeIndexTop
            {
                Paging = new ForPaging(Page)
            };
            switch (sormet)
            {
                case "low":
                    list.GetAllProductsList = productservice.GetAllproduct(Id, list.Paging).OrderBy(x => x.UnitPrice);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
                case "high":
                    list.GetAllProductsList = productservice.GetAllproduct(Id, list.Paging).OrderByDescending(x => x.UnitPrice);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
                default:
                    list.GetAllProductsList = productservice.GetAllproduct(Id, list.Paging);
                    list.GetAllCategories = categoryservice.GetCategoryList();
                    break;
            }
            return PartialView(list);
        }
        //public ActionResult _ProductListPartial()
        //{
        //    var list = productservice.ProductList();
        //    return PartialView(list);
        //}
        [Route("ProductItem/{Id}")]
        //單一商品頁面
        public ActionResult ProductItem(string Id)
        {
            //var list = new HomeIndexTop();
            //list.ProductsList = productservice.FindproductById(Id);
            var item = productservice.FindproductById(Id);
            return View(item);
        }
        //側邊分類欄
        public ActionResult CategoriesList()
        {
            return View();
        }
    }
}