using StoreData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class OrderView
    {
        public string orderId { get; set; }
        public IEnumerable<CustomerOrder> DataList { get; set; }
        public ForPaging Paging { get; set; }
    }
}