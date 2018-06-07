using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreData.Models
{
    [MetadataType(typeof(CategoriesMetadata))]
    public partial class Categories
    {
        private class CategoriesMetadata
        {
            public int CategoryID { get; set; }

            [DisplayName("類別名稱")]
            [Required(ErrorMessage = "請輸入類別")]
            public string CategoryName { get; set; }
        }
    }
}