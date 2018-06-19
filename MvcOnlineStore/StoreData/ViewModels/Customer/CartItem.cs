using StoreData.Models;
using StoreData.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StoreData.ViewModels.Customer
{
    public class CartItem
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string Path { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<Cart> GetAllChartList { get; set; }

    }
}