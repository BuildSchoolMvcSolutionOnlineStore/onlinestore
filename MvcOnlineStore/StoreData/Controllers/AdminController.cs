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
        private PayService payservice = new PayService();
        private DeliveryService deliveryService = new DeliveryService();
        private OrderDetailService orderDetailService = new OrderDetailService();
        private MessageService messageService = new MessageService();
        // GET: Admin
        //儀表板
        [Authorize(Roles = "Admin")]
        [Route("Dashboard")]
        public ActionResult Dashboard()
        {
            var Data = adminService.Dashboard();
            return View(Data);
        }
        //會員管理
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        public ActionResult Arrival(string orderId)
        {
            ordersService.UpdateStatus(orderId, 2);
            TempData["message"] = "訂單狀態變更為: 已到貨";
            return RedirectToRoute(new { Controller = "Admin", Action = "SearchOrder" });
        }

        //訂單明細
        [Authorize]
        [Route("OrderDetail/{orderId}")]
        public ActionResult OrderDetail(string orderId,int status,int OrderStatus)
        {
            var Data = new OrderDetailView();
            Data.OrderId = orderId;
            Data.Status = status;
            Data.OrderDataList = orderDetailService.GetAdminOrders(orderId);
            Data.MessageDataList = messageService.GetAdminMessage(orderId);
            Data.OrderStatus = OrderStatus;
            return View(Data);
        }
        //回覆留言
        [Route("ReplyMessage")]
        [HttpPost]
        public ActionResult ReplyMessage(string orderId,DateTime time,string reply,int status,int OrderStatus)
        {
            messageService.Update(orderId, time, reply);
            TempData["message"] = "已回覆留言";
            return RedirectToRoute(new { Controller="Admin",Action= "OrderDetail", orderId, status, OrderStatus });
        }
        [Authorize]
        [Route("Pay")]
        public ActionResult Pay()
        {
            var Data = payservice.paymentGetAll();
            return View(Data);
        }

        [Authorize]
        [Route("CreatePay")]
        public ActionResult CreatePay()
        {
            return View();
        }
        //新增付款方式
        [Route("CreatePay")]
        [HttpPost]
        public ActionResult CreatePay(PaymentMethods model)
        {
            payservice.Create(model);
            TempData["message"] = "成功新增付款方式";
            return RedirectToRoute(new { Controller = "Admin", Action = "CreatePay" });
        }
        //刪除付款方式
        [Route("DeletePay")]
        [HttpPost]
        public ActionResult DeletePay(int Id)
        {
            payservice.Delete(Id);
            TempData["message"] = "成功刪除付款方式";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Pay" });
        }
        public ActionResult UpdatePay(int Id)
        {
            var Data = payservice.FindById(Id);
            return PartialView(Data);
        }
        //修改付款方式
        [HttpPost]
        public ActionResult UpdatePay(PaymentMethods model)
        {
            payservice.UpdatePay(model);
            TempData["message"] = "成功修改付款方式";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Pay" });
        }

        [Authorize]
        [Route("Delivery")]
        public ActionResult Delivery()
        {
            var Data = deliveryService.deliveryGetAll();
            return View(Data);
        }

        [Authorize]
        [Route("CreateDelivery")]
        public ActionResult CreateDelivery()
        {
            return View();
        }
        //新增運送方式
        [Route("CreateDelivery")]
        [HttpPost]
        public ActionResult CreateDelivery(DeliveryMethods model)
        {
            deliveryService.Create(model);
            TempData["message"] = "成功新增運送方式";
            return RedirectToRoute(new { Controller = "Admin", Action = "CreateDelivery" });
        }
        //刪除運送方式
        [Route("DeleteDelivery")]
        [HttpPost]
        public ActionResult DeleteDelivery(int Id)
        {
            deliveryService.Delete(Id);
            TempData["message"] = "成功刪除運送方式";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Delivery" });
        }

        [Authorize]
        public ActionResult UpdateDelivery(int Id)
        {
            var Data = deliveryService.FindById(Id);
            return PartialView(Data);
        }
        //修改運送方式
        [HttpPost]
        public ActionResult UpdateDelivery(DeliveryMethods model)
        {
            deliveryService.UpdateDelivery(model);
            TempData["message"] = "成功修改運送方式";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Delivery" });
        }

        [Authorize]
        [Route("Category")]
        public ActionResult Category()
        {
            var Data = categoryService.CategoryGetAll();
            return View(Data);

        }
        [Authorize]
        [Route("CreateCategory")]
        public ActionResult CreateCategory()
        {
            return View();
        }
        //新增類別
        [Route("CreateCategory")]
        [HttpPost]
        public ActionResult CreateCategory(Categories model)
        {
            categoryService.Create(model);
            TempData["message"] = "成功新增類別";
            return RedirectToRoute(new { Controller = "Admin", Action = "CreateCategory" });
        }
        //刪除類別
        [Route("DeleteCategory")]
        [HttpPost]
        public ActionResult DeleteCategory(int Id)
        {
            categoryService.Delete(Id);
            TempData["message"] = "成功刪除類別";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Category" });
        }
        public ActionResult UpdateCategory(int Id)
        {
            var Data = categoryService.FindById(Id);
            return PartialView(Data);
        }
        //修改類別
        [HttpPost]
        public ActionResult UpdateCategory(Categories model)
        {
            categoryService.UpdateCategory(model);
            TempData["message"] = "成功修改類別";
            return RedirectToRoute(new { Controlller = "Admin", Action = "Category" });
        }
    }
}