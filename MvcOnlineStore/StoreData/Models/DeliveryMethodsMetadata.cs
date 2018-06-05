using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.Models
{
    [MetadataType(typeof(DeliveryMethodsMetadata))]
    public partial class DeliveryMethods
    {
        private class DeliveryMethodsMetadata
        {
            public int DeliveryMethodID { get; set; }

            [DisplayName("運送方式名稱")]
            [Required(ErrorMessage = "請輸入運送方式名稱")]
            public string DeliveryMethod { get; set; }

            [DisplayName("運費")]
            [Required(ErrorMessage ="請輸入運費")]
            public int Freight { get; set; }
        }
    }
}