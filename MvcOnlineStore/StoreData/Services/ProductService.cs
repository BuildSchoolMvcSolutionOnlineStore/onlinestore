using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;
using System.IO;

namespace StoreData.Services
{
    public class ProductService
    {
        private ProductsRepository productsRepository = new ProductsRepository();
        //修改庫存
        public void UpdateStock(string id,int stock)
        {
            var item = productsRepository.FindById(id);
            item.Stock = stock;
            productsRepository.Update(item);
        }
        //新增產品
        public void Create(Products model)
        {
            string Id = productsRepository.GetNewId();
            var split = Id.Split('A');
            string numner = (Convert.ToInt32(split[1]) + 1).ToString();
            while(numner.Length<3)
            {
                numner = "0" + numner;
            }
            model.ProductID = "A" + numner;
            productsRepository.Create(model);
        }
    }
}