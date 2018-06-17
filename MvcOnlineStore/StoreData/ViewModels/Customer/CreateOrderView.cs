using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CreateOrderView
    {
        public int PaymentMethodID { get; set; }
        public int DeliveryMethodID { get; set; }
    }
}