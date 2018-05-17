using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class OrderDetails
    {
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}