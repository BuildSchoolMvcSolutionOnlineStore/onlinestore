using StoreData.Models;
using StoreData.Services;
using StoreData.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StoreData.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        private CustomerService customerService = new CustomerService();
        private LoginService loginservice = new LoginService();
        private OrdersService ordersService = new OrdersService();
        private OrderDetailService orderDetailService = new OrderDetailService();
        private MessageService messageService = new MessageService();

        [Route("CustomerLogin")]
        public ActionResult CustomerLogin()
        {
            //if (User.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Home");
            return PartialView();
            //var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //if (cookie == null)
            //{
            //    ViewBag.IsAuthenticated = false;
            //    return View();
            //}
            //var ticket = FormsAuthentication.Decrypt(cookie.Value);
            //if (ticket.UserData == "abcdefg")
            //{
            //    ViewBag.IsAuthenticated = true;
            //    ViewBag.Username = "admin";
            //}
            //else
            //{
            //    ViewBag.IsAuthenticated = false;
            //}
            //return View();
        }
        [Route("CustomerLogin")]
        [HttpPost]
        public ActionResult CustomerLogin(CheckAccount model)
        {
            var Validatestr = loginservice.CustomerLoginCheck(model.CustomerID, model.CustomerPassword);
            if (String.IsNullOrEmpty(Validatestr))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.CustomerID, DateTime.Now, DateTime.Now.AddMinutes(30), false, "Customer", FormsAuthentication.FormsCookiePath);
                var enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                TempData["Message"] = "登入成功";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", Validatestr);
                TempData["Message"] = "帳號密碼錯誤";
                return RedirectToAction("Index", "Home");
            }
            //if (model.Username == "admin" && model.Password == "adpassword")
            //{
            //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "admin", DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");
            //    var ticketData = FormsAuthentication.Encrypt(ticket);
            //    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
            //    cookie.Expires = ticket.Expiration;
            //    Response.Cookies.Add(cookie);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("model", "使用者名稱或密碼不正確");
            //    ViewBag.IsAuthenticated = false;
            //    if (model.Username == "admin" && model.Password != "adpassword")
            //        ViewBag.Error = "使用者密碼不正確";
            //    if (model.Username == null)
            //        ViewBag.Error = "請輸入使用者帳號";
            //    if (model.Username != "admin" && model.Password != "adpassword" && model.Username != null)
            //        ViewBag.Error = "使用者帳號跟密碼不正確";
            //}
        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
        [Route("SelectCustomer")]
        public ActionResult SelectCustomer()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                string CustomerID = ticket.Name;
                return View(customerService.GetAccountByCustomers(CustomerID));
            }
            else
            {
                TempData["Message"] = "尚未登入會員";
                return RedirectToAction("Index", "Home");
            }
        }

        //修改客戶資料
        [HttpPost]
        public ActionResult UpdateCustomer(CustomerView model)
        {
            customerService.UpdateCustomer(model.CustomerID, model.CustomerPassword, model.CustomerName, model.Telephone, model.Address, model.CustomerMail);
            TempData["Message"] = "修改成功";
            return RedirectToAction("Index", "Home");
        }

        //判斷註冊帳號是否已被註冊過Action
        public JsonResult AccountCheck(CustomerRegisterView RegisterMember)
        {
            return Json(customerService.AccountCheck(RegisterMember.newCustomer.CustomerID), JsonRequestBehavior.AllowGet);
        }
        //註冊一開始顯示頁面
        [Route("Register")]
        public ActionResult Register()
        {
            return PartialView();
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(CustomerRegisterView RegisterMember)
        {
            if (ModelState.IsValid)
            {
                RegisterMember.newCustomer.CustomerPassword = RegisterMember.CustomerPassword;
                TempData["RegisterStatae"] = "註冊成功";
                return RedirectToAction("Index", "Home");
            }
            RegisterMember.CustomerPassword = null;
            RegisterMember.PasswordCheck = null;
            return RedirectToAction("Index", "Home");
        }
        //加入購物車
        public ActionResult Chart()
        {
            CartItem data = new CartItem();
            FormsIdentity id = (FormsIdentity)User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string CustomerID = ticket.Name;
            data.GetAllChartList = customerService.GetItemforcart(CustomerID);
            return View(data);
        }

        [HttpPost]
        public ActionResult AddChart(string ProductId, int Quantity)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                string CustomerID = ticket.Name;
                customerService.CartEvent(CustomerID, ProductId, Quantity);
                TempData["RegisterStatae"] = "成功加入購物車";
                return RedirectToAction("ProductItem", "Product", ProductId);
            }
            else
            {
                TempData["Message"] = "尚未登入會員";
                return RedirectToAction("Index", "Home");
            }
            
            
        }
        //取得目前使用者帳號
        public string Get_CustomerId()
        {
            FormsIdentity id = (FormsIdentity)User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            return ticket.Name;
        }
        [Route("OrderList")]
        public ActionResult OrderList(string orderId, int Page = 1)
        {
            var customerId = Get_CustomerId();
            var data = new OrderView() {
                orderId = orderId,
                Paging = new ForPaging(Page)
            };
            data.DataList = ordersService.GetCustomerOrderList(customerId, data.orderId,data.Paging);

            return View(data);
        }
        [Route("OrderDetailList/{orderId}")]
        public ActionResult OrderDetailList(string orderId,int amount)
        {
            var data = new OrderDetailView()
            {
                CustomerId = Get_CustomerId(),
                OrderId = orderId,
                Amount = amount,
            };
            data.OrderDetailDataList = orderDetailService.GetAdminOrders(data.OrderId);
            data.MessageDataList = messageService.GetAdminMessage(data.OrderId);
            return View(data);
        }
        [HttpPost]
        public ActionResult CreateMessage(string orderId, int amount,string Message)
        {
            messageService.Create(orderId, Message);
            return RedirectToAction("OrderDetailList", "Customer", new { orderId, amount });
        }
    }
}