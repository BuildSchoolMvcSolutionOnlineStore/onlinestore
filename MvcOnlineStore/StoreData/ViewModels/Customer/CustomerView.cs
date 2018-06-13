using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Customer
{
    public class CustomerView
    {
        [DisplayName("會員編號")]
        public string CustomerID { get; set; }

        [DisplayName("密碼")]
        public string CustomerPassword { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "請輸入姓名")]
        public string CustomerName { get; set; }

        [DisplayName("電話號碼")]
        [Required(ErrorMessage = "請輸入電話號碼")]
        public string Telephone { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "請輸入地址")]
        public string Address { get; set; }

        [DisplayName("電子郵件")]
        [Required(ErrorMessage = "請輸入電子郵件")]
        public string CustomerMail { get; set; }
    }
}