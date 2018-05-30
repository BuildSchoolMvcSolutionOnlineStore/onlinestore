using StoreData.Models;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class AdminService
    {
        private ProductsRepository productRepository = new ProductsRepository();
        public IEnumerable<AdminProduct> GetProductList(string Search, ForPaging Paging)
        {
            IEnumerable<AdminProduct> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = productRepository.GetAll_Admin();
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            else
            {
                Data = productRepository.SearchById_Admin(Search);
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            return Data.OrderBy(x => x.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
        public Products GetProduct(string Id)
        {
            var Data = productRepository.FindById(Id);
            return Data;
        }
    }
}