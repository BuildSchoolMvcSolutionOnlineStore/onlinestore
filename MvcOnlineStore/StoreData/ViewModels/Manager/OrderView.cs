using StoreData.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("數量")]
        [Required(ErrorMessage = "請輸入數字")]
        public int Num { get; set; }
    }
}