using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class Customers
    {
        public string CustomerID { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerName { get; set; }
        public int Telephone { get; set; }
        public string Address { get; set; }
        public string CustomerMail { get; set; }
    }
}
