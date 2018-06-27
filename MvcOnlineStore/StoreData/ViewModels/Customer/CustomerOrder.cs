using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CustomerOrder
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }

    }
}