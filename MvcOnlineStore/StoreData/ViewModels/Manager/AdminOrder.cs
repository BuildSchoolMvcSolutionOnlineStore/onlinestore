using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class AdminOrder
    {
        [DisplayName("訂單ID")]
        public string OrderId { get; set; }
        [DisplayName("客戶名稱")]
        public string CustomerName { get; set; }
        [DisplayName("訂單時間")]
        public DateTime OrderDate { get; set; }
        [DisplayName("出貨時間")]
        public DateTime? ShippedDate { get; set; }
        [DisplayName("付款方式")]
        public string PaymentMethod { get; set; }
        [DisplayName("運送方式")]
        public string DeliveryMethod { get; set; }
        [DisplayName("金額")]
        public string Amount { get; set; }
        [DisplayName("狀態")]
        public int Status { get; set; }
        [DisplayName("顧客留言")]
        public int Count { get; set; }
    }
}