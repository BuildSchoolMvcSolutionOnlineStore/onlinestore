using CoolPenLineBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolPenLineBot.Controllers
{
    public class TestLUISController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "IRFK88qhhSbtqeIXm2UfuwOpmt8Y0TTKA1O0tRrI09/q7ZyCdvSZw5ZEhidsqVFsAyV8EDaoUelY/8EFhMMgy0H8lpdoxfkc9IWSqbiQ5mqOHE/HPbtqKUwLpN6GiGMNFJL9fHZe3gbhqHpwnrnLbAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "Ud55d44b4fba33ca100be7dc95912141d";
        const string LuisAppId = "6afcc4a6-8091-4c67-b2dc-60266f0ffce2";
        const string LuisAppKey = "be3979d8d128468fb7550000b2726cf8";
        const string Luisdomain = "westus"; //ex.westus

        private OrderService orderService = new OrderService();
        private ProductService productService = new ProductService();
        [Route("api/TestLUIS")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    var repmsg = "";
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        //建立LuisClient
                        Microsoft.Cognitive.LUIS.LuisClient lc =
                          new Microsoft.Cognitive.LUIS.LuisClient(LuisAppId, LuisAppKey, true, Luisdomain);

                        //Call Luis API 查詢
                        var ret = lc.Predict(LineEvent.message.text).Result;
                        if (ret.Intents.Count() <= 0)
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但我看不懂喔!";
                        else if (ret.TopScoringIntent.Name == "None")
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但不在我的服務範圍內喔!";
                        else
                        {
                            //這裡去做判斷
                            //ret.TopScoringIntent.Name 語句的分類 EX: 訂單查詢 庫存查詢
                            //ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value  是 entities 裡第一個是什麼 第一個是 entity
                            if(ret.TopScoringIntent.Name == "訂單查詢")
                            {
                                repmsg = orderService.SearchOrder(ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value);
                            }
                            if(ret.TopScoringIntent.Name == "產品庫存")
                            {
                                    repmsg = productService.SearchProduct(ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value);
                            }
                            //repmsg = $"OK，你想 '{ret.TopScoringIntent.Name}'，";
                            //if (ret.Entities.Count > 0)
                            //    repmsg += $"想要的是 '{ ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value}' ";
                        }
                        //回覆
                        this.ReplyMessage(LineEvent.replyToken, repmsg);
                    }
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
