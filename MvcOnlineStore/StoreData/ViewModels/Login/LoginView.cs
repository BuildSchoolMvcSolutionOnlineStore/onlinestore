using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.ViewModels.Login
{
    public class LoginView
    {
        [DisplayName("員工編號")]
        [Required(ErrorMessage = "請輸入員工編號")]
        public string ManagerID { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string ManagerPassword { get; set; }
    }
}