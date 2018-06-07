using StoreData.Models;
using StoreData.Services;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        //services
        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private AdminService adminService = new AdminService();
        private CategoryService categoryService = new CategoryService();
        private OrdersService ordersService = new OrdersService();
        private OrderDetailService orderDetailService = new OrderDetailService();
        private MessageService messageService = new MessageService();
        // GET: Admin
        //儀表板
        [Route("")]
        public ActionResult Index()
        {
            var Data = adminService.Dashboard();
            return View(Data);
        }
        //會員管理

        [Route("Members")]
        public ActionResult Members(string Id, int Page = 1)
        {
            var Data = new MemberView
            {
                Search = Id,
                Paging = new ForPaging(Page)
            };
            Data.DataList = customerService.CustomerList(Data.Search, Data.Paging);
            return View(Data);
        }

        //產品管理
        [Route("Products")]
        public ActionResult Products(string Id, int Page = 1)
        {
            var Data = new ProductView
            {
                Search = Id,
                Paging = new ForPaging(Page)
            };
            Data.DataList = productService.GetProductList(Data.Search, Data.Paging);
            return View(Data);
        }

        //修改產品庫存
        [HttpPost]
        public ActionResult UpdateStock(string Id, int stock, string search, int Page)
        {
            productService.UpdateStock(Id, stock);
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products", Id = search, Page });
        }

        //新增產品
        [Route("CreateProduct")]
        public ActionResult CreateProduct()
        {
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
            return View();
        }
        [Route("CreateProduct")]
        [HttpPost]
        public ActionResult CreateProduct(Products model, HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            model.Path = fileName;
            productService.Create(model);
            var path = Path.Combine(Server.MapPath("~/FileUploads/"), fileName);
            file.SaveAs(path);
            TempData["message"] = "成功新增商品";
            return RedirectToRoute(new { Controlller = "Admin", Action = "CreateProduct" });
        }

        //修改產品
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct(string Id)
        {
            var Data = productService.GetProduct(Id);
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
            if (file == null)
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
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products" });
        }

        //刪除產品
        [Route("DeleteProduct")]
        [HttpPost]
        public ActionResult DeleteProduct(string Id)
        {
            productService.Delete(Id);
            TempData["message"] = "成功刪除商品";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Products" });
        }

        //訂單列表
        [Route("SearchOrder")]
        public ActionResult SearchOrder(string Id, int OrderStatus = -1, int Page = 1)
        {
            var Data = new OrderView
            {
                Search = Id,
                Paging = new ForPaging(Page),
                OrderStatus = OrderStatus
            };
            if(OrderStatus != -1)
            {
                Data.DataList = ordersService.GetOrderList(Data.Search, Data.Paging, OrderStatus);
            }
            else
            {
                Data.DataList = ordersService.GetOrderList(Data.Search, Data.Paging);
            }
            TempData["orderStatus"] = OrderStatus;
            return View(Data);
        }
        //出貨按鈕
        [Route("Shipping")]
        [HttpPost]
        public ActionResult Shipping(string orderId)
        {
            ordersService.UpdateStatus(orderId, 1);
            TempData["message"] = "訂單狀態變更為: 已出貨";
            return RedirectToRoute(new { Controller = "Admin", Action = "SearchOrder"});
        }

        //到貨按鈕
        [Route("Arrival")]
        [HttpPost]
        public ActionResult Arrival(string orderId, string action)
        {
            ordersService.UpdateStatus(orderId, 2);
            TempData["message"] = "訂單狀態變更為: 已到貨";
            return RedirectToRoute(new { Controller = "Admin", Action = action });
        }

        //訂單明細
        [Route("OrderDetail/{orderId}")]
        public ActionResult OrderDetail(string orderId,int status,string str,int OrderStatus)
        {
            var Data = new OrderDetailView();
            Data.OrderId = orderId;
            Data.Status = status;
            Data.OrderDataList = orderDetailService.GetAdminOrders(orderId);
            Data.MessageDataList = messageService.GetAdminMessage(orderId);
            Data.OrderStatus = OrderStatus;
            ViewBag.Action = str;
            return View(Data);
        }
        //回覆留言
        [Route("ReplyMessage")]
        [HttpPost]
        public ActionResult ReplyMessage(string orderId,DateTime time,string reply,string str,string status)
        {
            messageService.Update(orderId, time, reply);
            TempData["message"] = "已回覆留言";
            return RedirectToRoute(new { Controller="Admin",Action= "OrderDetail", orderId, status, str });
        }
    }
}