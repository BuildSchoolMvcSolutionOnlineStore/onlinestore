using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class OrderDetailView
    {
        public string OrderId { get; set; }
        public int Status { get; set; }
        public IEnumerable<AdminOrderDetail> OrderDataList { get; set; }
        public IEnumerable<Messages> MessageDataList { get; set; }
        public int OrderStatus { get; set; }
    }
}