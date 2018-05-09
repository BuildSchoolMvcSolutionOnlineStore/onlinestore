using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class Products
    {
        public string ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set;}
        public int Stock { get; set; }
        public int UnitPrice { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Instructions { get; set; }
    }
}
