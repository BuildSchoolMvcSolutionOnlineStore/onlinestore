using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Home
{
    public class ProductsItem
    {
        public string ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string Path { get; set; }  
    }
}