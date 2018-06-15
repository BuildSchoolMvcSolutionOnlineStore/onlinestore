using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CheckAccount
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string CustomerID { get; set; }


        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string CustomerPassword { get; set; }
    }
}