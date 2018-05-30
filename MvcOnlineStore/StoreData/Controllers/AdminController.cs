using StoreData.Models;
using StoreData.Services;
using StoreData.ViewModels.Manager;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private AdminService adminService = new AdminService();
        private CategoryService categoryService = new CategoryService();
        private OrdersService ordersService = new OrdersService();

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

        [Route("UpdateProduct")]
        public ActionResult UpdateProduct(string Id)
        {
            var Data = adminService.GetProduct(Id);
            var categories = categoryService.GetCategoryList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in categories)
            {
                items.Add(new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryID.ToString()
                });
            }
            ViewBag.CategoryItems = items;

            return View(Data);
        }
        [Route("UpdateProduct")]
        [HttpPost]
        public ActionResult UpdateProduct(Products model, HttpPostedFileBase file)
        {
            if(file == null)
            {
                productService.Update(model);
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                model.Path = fileName;
                productService.Update(model);
                var path = Path.Combine(Server.MapPath("~/FileUploads/"), fileName);
                file.SaveAs(path);
            }

            TempData["message"] = "成功修改商品";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products"});
        }
        [Route("DeleteProduct")]
        [HttpPost]
        public ActionResult DeleteProduct(string Id)
        {
            productService.Delete(Id);
            TempData["message"] = "成功刪除商品";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products" });
        }
        [Route("UnDeliveryOrder")]
        public ActionResult UnDeliveryOrder(string Id, int Page = 1)
        {
            var list =  ordersService.OrdersList_Status_0();
            return View(list);
        }
    }
}