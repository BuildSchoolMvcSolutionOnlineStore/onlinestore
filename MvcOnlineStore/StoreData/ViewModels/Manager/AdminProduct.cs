using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class AdminProduct
    {
        public string ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int UnitPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}