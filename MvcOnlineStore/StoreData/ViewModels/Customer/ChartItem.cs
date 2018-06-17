using StoreData.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace StoreData.ViewModels.Customer
{
    public class ChartItem
    {
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string Path { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<ChartItem> GetAllChartList { get; set; }

    }
}