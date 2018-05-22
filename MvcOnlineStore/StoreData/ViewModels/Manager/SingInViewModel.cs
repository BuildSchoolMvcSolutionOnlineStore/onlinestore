using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Manager
{
    public class SingInViewModel
    {
        [Required(ErrorMessage ="請輸入使用者名稱")]
        [Display(Name = "使用者名稱 : ")]
        public string account { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼 : ")]
        public string password { get; set; }
    }
}