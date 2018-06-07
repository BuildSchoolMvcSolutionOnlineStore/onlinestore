using StoreData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class OrderView
    {
        public string Search { get; set; }
        public IEnumerable<AdminOrder> DataList { get; set; }
        public ForPaging Paging { get; set; }
        public int OrderStatus { get; set; }
    }
}