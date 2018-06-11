using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoolPenLineBot
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "IRFK88qhhSbtqeIXm2UfuwOpmt8Y0TTKA1O0tRrI09/q7ZyCdvSZw5ZEhidsqVFsAyV8EDaoUelY/8EFhMMgy0H8lpdoxfkc9IWSqbiQ5mqOHE/HPbtqKUwLpN6GiGMNFJL9fHZe3gbhqHpwnrnLbAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "Ud55d44b4fba33ca100be7dc95912141d";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}