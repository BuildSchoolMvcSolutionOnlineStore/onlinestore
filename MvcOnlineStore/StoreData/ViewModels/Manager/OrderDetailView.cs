using StoreData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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


        [DisplayName("數量")]
        [Required(ErrorMessage = "請輸入數字")]
        public int Num { get; set; }
    }
}