using StoreData.Models;
using StoreData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class MemberView
    {
        public string Search { get; set; }
        public IEnumerable<Customers> DataList { get; set; }
        public ForPaging Paging { get; set; }
    }
}