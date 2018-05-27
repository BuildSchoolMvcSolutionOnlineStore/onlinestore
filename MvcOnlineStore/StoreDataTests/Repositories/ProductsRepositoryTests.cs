using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories.Tests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void GetAll_AdminTest()
        {
            ProductsRepository repository = new ProductsRepository();
            var list = repository.GetAll_Admin();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void SearchById_AdminTest()
        {
            ProductsRepository repository = new ProductsRepository();
            var list = repository.SearchById_Admin("A001");
            Assert.IsTrue(list.Count() > 0);
        }
    }
}