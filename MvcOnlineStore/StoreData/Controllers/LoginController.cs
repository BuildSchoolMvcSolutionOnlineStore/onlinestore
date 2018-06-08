using StoreData.Services;
using StoreData.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StoreData.Controllers
{
    public class LoginController : Controller
    {
        private LoginService LoginService = new LoginService();
        
        // GET: Login
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Admin");//登入後導向後台主畫面
            return View();
        }
        
        [HttpPost]
        public ActionResult LoginCheck(LoginView loginemployee)
        {
            var Validatestr = LoginService.LoginCheck(loginemployee.ManagerID, loginemployee.ManagerPassword);
            if(String.IsNullOrEmpty(Validatestr))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, loginemployee.ManagerID, DateTime.Now, DateTime.Now.AddMinutes(30), false, "12345", FormsAuthentication.FormsCookiePath);
                var enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", Validatestr);
                return View(loginemployee);
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}