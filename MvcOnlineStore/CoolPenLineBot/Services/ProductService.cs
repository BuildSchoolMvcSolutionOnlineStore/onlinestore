using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.ViewModels.Home;

namespace CoolPenLineBot.Services
{
    public class ProductService
    {
        private ProductsRepository repository = new ProductsRepository();
        public string SearchProduct(string productName)
        {
            IEnumerable<ProductsItem> data = repository.SearchByProductName(productName);
            if (data.Count() != 0)
            {
                var str = "";
                foreach (var item in data)
                {
                    str += $"產品名稱: {item.ProductName}\n" +
                    $"價錢: {item.UnitPrice}\n" +
                    $"剩餘數量: {item.Stock}\n" +
                    $"網址: http://mvconlineshopteam7.azurewebsites.net/Product/ProductItem/" + item.ProductID + "\n\n";
                }
                return str;
            }
            else
            {
                return "很抱歉沒有搜尋到有關於這項產品的相關項目";
            }
        }
    }
}