using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.Models
{
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products
    {
        private class ProductsMetadata
        {
            public string ProductID { get; set; }
            public int CategoryID { get; set; }

            [DisplayName("產品名稱")]
            [Required(ErrorMessage ="請輸入產品名稱")]
            public string ProductName { get; set; }

            [DisplayName("數量")]
            [Required(ErrorMessage = "請輸入數量")]
            public int Stock { get; set; }

            [DisplayName("單價")]
            [Required(ErrorMessage = "請輸入單價")]
            public int UnitPrice { get; set; }

            [DisplayName("大小")]
            [Required(ErrorMessage = "請輸入大小")]
            public string Size { get; set; }

            [DisplayName("顏色")]
            [Required(ErrorMessage = "請輸入顏色")]
            public string Color { get; set; }

            [DisplayName("產品介紹")]
            [Required(ErrorMessage = "請輸入文字")]
            public string Instructions { get; set; }

            public string Path { get; set; }
        }
    }
    
}