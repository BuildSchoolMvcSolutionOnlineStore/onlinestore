using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreData.Models;
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
        private CategoryService categoryService = new CategoryService();

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

        [Route("CreateProduct")]
        public ActionResult CreateProduct()
        {
            var categories = categoryService.GetCategoryList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var category in categories)
            {
                items.Add(new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryID.ToString()
                });
            }
            ViewBag.CategoryItems = items;
            return View();
        }
        [Route("CreateProduct")]
        [HttpPost]
        public ActionResult CreateProduct(Products model,HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            model.Path = fileName;
            productService.Create(model);
            var path = Path.Combine(Server.MapPath("~/FileUploads/"), fileName);
            file.SaveAs(path);
            TempData["message"] = "成功新增商品";
            return RedirectToRoute(new { Controlller = "Admin", Action = "CreateProduct" });
        }
    }
}