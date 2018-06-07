using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
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

            var payload = "client_id=368194773689774" +
                "&redirect_uri=" + HttpUtility.UrlEncode("https://mvconlineshopteam7.azurewebsites.net") +
                "&client_secret=" + ConfigurationManager.AppSettings["facebook:secret"] +
                "&code=" + code;

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = client.UploadString(tokenEndPoint, payload);

            //物件
            var str_json = JObject.Parse(response);
            //自串
            var accessToken = str_json.Property("access_token").Value.ToString();

            //顯示存取權杖
            ViewBag.accessToken = (accessToken);

            //抓資料的東西 => 圖形介面
            var profile = client.DownloadString("https://graph.facebook.com/me?access_token=" + accessToken);

            var Info = JObject.Parse(profile);
            var id = Info.Property("id").Value.ToString();
            var name = Info.Property("name").Value.ToString();

            ViewBag.Facebook = id;

            //登入或註冊


            return RedirectToAction("Index","Home");
        }
    }
}