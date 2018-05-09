using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Repository.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new
                BuildSchool.MvcSolution.OnlineStore.Repository.CustomerRepository();

            var list = repository.GetAll();
            Assert.IsTrue(list.Count() == 0);
        }
    }
}