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
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void FindByIdTest()
        {
            var repository = new OrdersRepository();
            var text = repository.FindOrdersByOrderId("1");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new OrdersRepository();
            var list = repository.GetAllOrders();
            Assert.IsTrue(list.Count()>0);
        }
    }
}