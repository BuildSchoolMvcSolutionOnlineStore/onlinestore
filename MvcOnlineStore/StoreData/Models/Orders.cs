using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class Orders
    {
        public string OrderID {get;set;}
        public string CustomerID {get;set;}
        public DateTime OrderDate  {get;set;}
        public DateTime? ShippedDate {get;set;}
        public int PaymentMethodID {get;set;}
        public int DeliveryMethodID {get;set;}
        public int Status { get; set; }
    }
}
