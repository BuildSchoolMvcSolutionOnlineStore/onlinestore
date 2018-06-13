using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreData.Services;
using StoreData.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Services.Tests
{
    [TestClass()]
    public class OrdersServiceTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var service = new OrdersService();
            var model = new CreateOrderView()
            {
                PaymentMethodID = 1,
                DeliveryMethodID = 1
            };
            string remsg = service.Create("Betty", model);

            Assert.IsTrue(remsg == "訂單成立");
        }

        [TestMethod()]
        public void CreateTest_IsFalse()
        {
            var service = new OrdersService();
            var model = new CreateOrderView()
            {
                PaymentMethodID = 1,
                DeliveryMethodID = 1
            };
            string remsg = service.Create("Alison",model);

            Assert.IsTrue(remsg != "訂單成立");
        }

        [TestMethod()]
        public void CreateOrderTest()
        {
            var service = new OrdersService();
            var model = new CreateOrderView()
            {
                PaymentMethodID = 1,
                DeliveryMethodID = 1
            };
            service.CreateOrder("Doris", model);

            Assert.IsTrue(true);
        }
    }
}