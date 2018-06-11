using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolPenLineBot.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "IRFK88qhhSbtqeIXm2UfuwOpmt8Y0TTKA1O0tRrI09/q7ZyCdvSZw5ZEhidsqVFsAyV8EDaoUelY/8EFhMMgy0H8lpdoxfkc9IWSqbiQ5mqOHE/HPbtqKUwLpN6GiGMNFJL9fHZe3gbhqHpwnrnLbAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "Ud55d44b4fba33ca100be7dc95912141d";

        [Route("api/LineWebHookSample")]
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
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        if(LineEvent.message.text.ToLower() == "查詢")
                        {
                            var action = new List<isRock.LineBot.TemplateActionBase>();
                            action.Add(new isRock.LineBot.MessageAction()
                            {
                                label = "新訂單數量",
                                text = "回覆文字"
                            });
                            action.Add(new isRock.LineBot.UriAction()
                            {
                                label = "標題-開啟文字",
                                uri = new Uri("https://www.google.com")
                            });
                            action.Add(new isRock.LineBot.PostbackAction()
                            {
                                label = "標題-發生postack",
                                data = "abc=aaa%def=111"
                            });
                            action.Add(new isRock.LineBot.DateTimePickerAction()
                            {
                                label = "請選擇時間",
                                mode = "datetime"
                            });

                            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
                            {
                                text = "ButtonsTemplate文字訊息",
                                title = "ButtonsTemplate標題",
                                thumbnailImageUrl = new Uri("https://fakeimg.pl/300x250"),
                                actions = action
                            };
                            this.ReplyMessage(LineEvent.replyToken, ButtonTemplate);
                        }
                    }
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                if (LineEvent.type == "postback")
                {
                    var data = LineEvent.postback.data;
                    var dt = LineEvent.postback.Params.datetime;
                    this.ReplyMessage(LineEvent.replyToken, $"觸發了postback \n 資料為 {data} \n 選擇結果:{dt}");
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
