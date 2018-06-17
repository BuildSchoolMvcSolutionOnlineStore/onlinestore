using StoreData.Models;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("留言")]
        [Required(ErrorMessage ="留言不可為空值")]
        public string Message { get; set; }
    }
}