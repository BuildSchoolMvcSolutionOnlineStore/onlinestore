using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class MessageService
    {
        private MessagesRepository messagesRepository = new MessagesRepository();
        public IEnumerable<Messages> GetAdminMessage(string Id)
        {
            var list = messagesRepository.FindById_Admin(Id);
            return list;
        }
        public void Update(string orderId, DateTime time, string reply)
        {
            var item = GetAdminMessage(orderId).FirstOrDefault(x => x.Time == time);
            item.Reply = reply;
            item.ReplyTime = DateTime.Now;
            messagesRepository.Update(item);
        }
    }
}