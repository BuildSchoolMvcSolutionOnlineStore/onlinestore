using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;
using System.IO;
using StoreData.ViewModels.Home;

namespace StoreData.Services
{
    public class ProductService
    {
        private ProductsRepository productsRepository = new ProductsRepository();
        private CategoryService categoryservice = new CategoryService();
        //修改庫存
        public void UpdateStock(string id,int stock)
        {
            var item = productsRepository.FindById(id);
            item.Stock = stock;
            productsRepository.Update(item);
        }
        //修改庫存(加法)
        public void UpdateStock_diff(string id, int diff)
        {
            var item = productsRepository.FindById(id);
            item.Stock = item.Stock-diff;
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
        //修改產品
        public void Update(Products model)
        {
            productsRepository.Update(model);
        }
        //刪除產品
        public void Delete(string Id)
        {
            productsRepository.Delete(Id);
        }
        //管理者用的產品列表
        public IEnumerable<AdminProduct> GetProductList(string Search, ForPaging Paging)
        {
            IEnumerable<AdminProduct> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = productsRepository.GetAll_Admin();
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            else
            {
                Data = productsRepository.SearchById_Admin(Search);
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            return Data.OrderBy(x => x.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
        // 顯示產品
        public IEnumerable<ProductsItem> GetProductsList()
        {
            var Data = productsRepository.FindById_Home();
            return Data;
        }

        // 搜尋產品
        public IEnumerable<ProductsItem> GetSearchProductName(string Search, ForPaging Paging)
        {
            IEnumerable<ProductsItem> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = productsRepository.GetAll();
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            else
            {
                Data = productsRepository.SearchByProductName(Search);
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            return Data.OrderBy(x => x.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
        //取得單一產品
        public Products GetProduct(string Id)
        {
            var Data = productsRepository.FindById(Id);
            return Data;
        }
        //尋找產品ID
        public ProductsItem FindproductById(string Id)
        {
            var result = productsRepository.FindByProductItemId(Id);
            return result;
        }
        //所有產品
        public IEnumerable<ProductsItem> GetAllproduct(int Id, ForPaging Paging)
        {
            var result = productsRepository.GetAll().Where((x)=>x.CategoryID == Id);
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(result.Count()) / Paging.ItemNum));
            Paging.SetRightPage();
            return result.OrderBy(x => x.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }

    }
}