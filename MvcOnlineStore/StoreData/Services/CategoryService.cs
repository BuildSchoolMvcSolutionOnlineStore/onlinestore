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
        public IEnumerable<Categories> CategoryGetAll()
        {
            var Data = categoriesRepository.GetAll();
            return Data;
        }

        public void Create(Categories item)
        {
            var Data = categoriesRepository.FindLastCategoryID() + 1;
            item.CategoryID = Data;
            categoriesRepository.Create(item);
        }

        public void Delete(int Id)
        {
            categoriesRepository.Delete(Id);
        }
        public void UpdateCategory(Categories item)
        {
            categoriesRepository.Update(item);
        }
        public Categories FindById(int Id)
        {
            var Data = categoriesRepository.FindById(Id);
            return Data;
        }
    }
}