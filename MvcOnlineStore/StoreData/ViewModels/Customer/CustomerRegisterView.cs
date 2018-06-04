using StoreData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CustomerRegisterView
    {
        public Customers newCustomer { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage ="請輸入密碼")]
        public string CustomerPassword { get; set; }

        [DisplayName("確認密碼")]
        [Compare("CustomerPassword",ErrorMessage ="兩次密碼輸入不一致")]
        [Required(ErrorMessage ="請輸入確認密碼")]
        public string PasswordCheck { get; set; }
    }
}