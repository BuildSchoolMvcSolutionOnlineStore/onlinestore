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
    public class CustomersRepositoryTests
    {
        private CustomersRepository repository = new CustomersRepository();
        [TestMethod()]
        public void SearchByIdTest()
        {
            var list = repository.SearchById("Jhon");
            Assert.IsTrue(list.Count() > 0);
        }
    }
}