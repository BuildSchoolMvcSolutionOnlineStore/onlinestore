using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;

namespace StoreData.Services
{
    public class ProductService
    {
        private ProductsRepository repository = new ProductsRepository();
        public IEnumerable<Products> ProductList(string Search, ForPaging Paging)
        {
            IEnumerable<Products> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = repository.GetAll();
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            else
            {
                Data = repository.SearchById(Search);
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            return Data.OrderBy(x => x.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
    }
}