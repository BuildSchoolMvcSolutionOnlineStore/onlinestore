using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Controllers
{
    [RoutePrefix("facebookAuth")]
    public class FacebookController : Controller
    {
        [Route("")]
        // GET: Facebook
        public ActionResult Index()
        {
            var url = "https://www.facebook.com/v3.0/dialog/oauth?" +
                "client_id=368194773689774"+
                "&redirect_uri=https://mvconlineshopteam7.azurewebsites.net/facebookAuth/verification" +
                "&response_type=code";

            return Redirect(url);
        }
        [Route("verification")]
        public ActionResult Verification()
        {
            var code = Request.QueryString["code"];
            var tokenEndPoint = "https://graph.facebook.com/v3.0/oauth/access_toke";


            return RedirectToAction("Index","Home");
        }
    }
}