using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.Models;

namespace StoreData.Services
{
    public class CategoryService
    {
        private CategoriesRepository categoriesRepository = new CategoriesRepository();
        public IEnumerable<Categories> GetCategoryList()
        {
            var list = categoriesRepository.GetAll();
            return list;
        }
    }
}