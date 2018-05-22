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
        public IEnumerable<Products> ProductList()
        {
            return repository.GetAll();
        }
    }
}