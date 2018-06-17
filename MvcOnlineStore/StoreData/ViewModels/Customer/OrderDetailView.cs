using StoreData.Models;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class OrderDetailView
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public IEnumerable<Messages> MessageDataList { get; set; }
        public IEnumerable<AdminOrderDetail> OrderDetailDataList { get; set; }
    }
}