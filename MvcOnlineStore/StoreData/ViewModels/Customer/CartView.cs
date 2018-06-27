using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CartView
    {
        public int DeliveryMethodID { get; set; }
        public int PaymentMethodID { get; set; }
        public IEnumerable<CartItem> DataList { get; set; }
    }
}