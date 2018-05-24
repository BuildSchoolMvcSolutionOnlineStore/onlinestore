using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class SingInViewModel
    {
        
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入會員帳號")]
        public string account { get; set; }
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string password { get; set; }
    }
}