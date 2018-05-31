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
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void GetAll_AdminTest()
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var list = ordersRepository.GetAll_Admin();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void SearchById_AdminTest()
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var list = ordersRepository.SearchById_Admin("DE001");
            Assert.IsTrue(list.Count() >= 1);
        }

        [TestMethod()]
        public void GetAmountTest()
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var amount = ordersRepository.GetAmount();
            Assert.IsTrue(amount > 0);
        }

        [TestMethod()]
        public void GetNewOrderCountTest()
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var count = ordersRepository.GetNewOrderCount();
            Assert.IsTrue(count > 0);
        }
    }
}