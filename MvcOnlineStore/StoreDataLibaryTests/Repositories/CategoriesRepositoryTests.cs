using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MvcSolution.OnlineStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories.Tests
{
    [TestClass()]
    public class CategoriesRepositoryTests
    {
        [TestMethod()]
        public void Categories_FindByIdTest()
        {
            var repository = new CategoriesRepository();
            var text = repository.FindCategoryByCategoryID(1);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Categories_GetAllTest()
        {
            var repository = new CategoriesRepository();
            var list = repository.GetAllCategories();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void Categories_1_CreateCategoryTest()
        {
            var repository = new CategoriesRepository();
            var model = new Categories
            {
                CategoryID = 666,
                CategoryName = "商品測試"
            };
            repository.CreateCategory(model);
            var text = repository.FindCategoryByCategoryID(666);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Categories_2_UpdateCategoryTest()
        {
            var repository = new CategoriesRepository();
            var oldModel = repository.FindCategoryByCategoryID(666);
            oldModel.CategoryName = "已被修改";
            repository.UpdateCategory(oldModel);
            var text = repository.FindCategoryByCategoryID(666);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Categories_3_DeleteCategoryTest()
        {
            var repository = new CategoriesRepository();
            var oldModel = repository.FindCategoryByCategoryID(666);
            repository.DeleteCategory(666);

            var text = repository.FindCategoryByCategoryID(666);
            Assert.IsTrue(text == null);
        }
    }
}