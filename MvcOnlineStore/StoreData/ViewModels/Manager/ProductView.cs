using StoreData.Models;
using StoreData.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class ProductView
    {
        public string Search { get; set; }
        public IEnumerable<AdminProduct> DataList { get; set; }
        public ForPaging Paging { get; set; }

        [DisplayName("庫存")]
        [Required(ErrorMessage ="請輸入數字")]
        public int Stock { get; set; }
    }
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