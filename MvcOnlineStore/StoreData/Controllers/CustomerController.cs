using StoreData.Models;
using StoreData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StoreData.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult CustomerLogin()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                ViewBag.IsAuthenticated = false;
                return View();
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket.UserData == "abcdefg")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = "admin";
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(CustomerLogin model)
        {
            if (model.Username == "admin" && model.Password == "adpassword")
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "admin", DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");
                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("model", "使用者名稱或密碼不正確");
                ViewBag.IsAuthenticated = false;
                if (model.Username == "admin" && model.Password != "adpassword")
                    ViewBag.Error = "使用者密碼不正確";
                if (model.Username == null)
                    ViewBag.Error = "請輸入使用者帳號";
                if (model.Username != "admin" && model.Password != "adpassword" && model.Username != null)
                    ViewBag.Error = "使用者帳號跟密碼不正確";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index","Home");
        }
        //客戶登入
        public ActionResult SingIn()
        {
            return View();
        }

        //新增客戶資料
        public ActionResult CreateCustomer()
        {
            return View();
        }

        //修改客戶資料
        public ActionResult UpdateCustomer()
        {
            return View();
        }
    }
}