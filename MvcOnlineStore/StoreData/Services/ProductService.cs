using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;

namespace StoreData.Services
{
    public class ProductService
    {
        private ProductsRepository productsRepository = new ProductsRepository();
        public void UpdateStock(string id,int stock)
        {
            var item = productsRepository.FindById(id);
            item.Stock = stock;
            productsRepository.Update(item);
        }
    }
}