using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreData.Models
{   [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        private class CustomerMetadata
        {
            [DisplayName("帳號")]
            [Required(ErrorMessage = "請輸入帳號")]
            [StringLength(30, MinimumLength = 6, ErrorMessage = "帳號長度須介於6-30字元")]
            [Remote("AccountCheck", "Customer", ErrorMessage = "此帳號已被註冊過")]
            public string CustomerID { get; set; }
            public string CustomerPassword { get; set; }

            [DisplayName("姓名")]
            [StringLength(20, ErrorMessage = "姓名長度最多20個字元")]
            [Required(ErrorMessage = "請輸入姓名")]
            public string CustomerName { get; set; }

            [DisplayName("電話")]
            [RegularExpression(@"^[0-9]''-'\s){10}$")]
            [StringLength(10,ErrorMessage ="輸入電話格式不對")]
            [Required(ErrorMessage ="請輸入電話")]
            public string Telephone { get; set; }

            [DisplayName("地址")]
            [Required(ErrorMessage ="請輸入地址")]
            public string Address { get; set; }

            [DisplayName("CustomerMail")]
            [Required(ErrorMessage = "請輸入Email")]
            [StringLength(200, ErrorMessage = "Email 長度最多200字元")]
            [EmailAddress(ErrorMessage = "這不是Email格式")]
            public string CustomerEmail { get; set; }
        }
    }
}