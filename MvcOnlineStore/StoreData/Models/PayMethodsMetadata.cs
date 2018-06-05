using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.Models
{
    [MetadataType(typeof(PaymentMethodsMetadata))]
    public partial class PaymentMethods
    {
        private class PaymentMethodsMetadata
        {
            public int PaymentMethodID { get; set; }

            [DisplayName("付款方式名稱")]
            [Required(ErrorMessage = "請輸入付款方式名稱")]
            public string PaymentMethod { get; set; }
        }
    }

}