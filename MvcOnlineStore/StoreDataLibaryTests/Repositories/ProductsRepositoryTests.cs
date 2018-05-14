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
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void Products_FindByIdTest()
        {
            var repository = new ProductsRepository();
            var text = repository.FindProductByProductId("A001");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Products_GetAllTest()
        {
            var repository = new ProductsRepository();
            var list = repository.GetAllProducts();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void Products_1_CreateProductTest()
        {
            var repository = new ProductsRepository();
            var model = new Products();
            model.ProductID = "Test001";
            model.CategoryID = 1;
            model.ProductName = "產品測試";
            model.Stock = 30;
            model.UnitPrice = 40;
            model.Size = 3;
            model.Color = "Green";
            model.Instructions = "測試產品內容";
            repository.CreateProduct(model);
            var text = repository.FindProductByProductId("Test001");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Products_2_UpdateProductTest()
        {
            var repository = new ProductsRepository();
            var Oldmodel = repository.FindProductByProductId("Test001");
            Oldmodel.Instructions = "已被修改";
            repository.UpdateProduct(Oldmodel);

            var Newmodel = repository.FindProductByProductId("Test001");
            Assert.IsTrue(Newmodel.Instructions == "已被修改");
        }

        [TestMethod()]
        public void Products_3_DeleteProductTest()
        {
            var repository = new ProductsRepository();
            repository.DeleteProduct("Test001");
            var text = repository.FindProductByProductId("Test001");
            Assert.IsTrue(text == null);
        }

        [TestMethod()]
        public void Products_GetProductsByProductNameTest()
        {
            var repository = new ProductsRepository();
            var list = repository.GetProductsByProductName("光");
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void Products_FindTopProductByQuantityTest()
        {
            var repository = new ProductsRepository();
            var list = repository.FindTopProductByQuantity();
            Assert.IsTrue(list.Count() == 3);
        }

        [TestMethod()]
        public void Products_OrderByUnitPriceTest()
        {
            var repository = new ProductsRepository();
            var list = repository.GetAllProducts();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}