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
    public class CustomersRepositoryTests
    {
        [TestMethod()]
        public void FindByIdTest()
        {
            var repository = new CustomersRepository();
            var text = repository.FindById("1");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new CustomersRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}