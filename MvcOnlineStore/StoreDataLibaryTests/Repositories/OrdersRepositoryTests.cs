using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MvcSolution.OnlineStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MvcSolution.OnlineStore.Models.Models;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories.Tests
{
    [TestClass()]
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void Orders_FindByIdTest()
        {
            var repository = new OrdersRepository();
            var text = repository.FindOrdersByOrderId("MB9487");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Orders_GetAllTest()
        {
            var repository = new OrdersRepository();
            var list = repository.GetAllOrders();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void CreateOrdersTest()
        {
            var repository = new OrdersRepository();
            var model = new Orders();
            model.OrderID = "Test87";
            model.CustomerID = 87;
            model.OrderDate = new DateTime(2018 / 12 / 12);
            model.ShippedDate = new DateTime(2018, 1, 1);
            model.PaymentMethodID = 88;
            model.DeliveryMethodID = 89;
            Assert.IsTrue(model.OrderID != null);
        }

        [TestMethod()]
        public void UpdateOrdersTest()
        {
            var repository = new OrdersRepository();
            var Ordersmodel = repository.FindOrdersByOrderId("Test87");
            Ordersmodel.CustomerID = 9487;
            repository.UpdateOrders(Ordersmodel);
            var Newmodel = repository.FindOrdersByOrderId("Test87");
            Assert.IsTrue(Newmodel.CustomerID == 9487);
        }

        [TestMethod()]
        public void DeleteOrdersTest()
        {
            var repository = new OrdersRepository();
            repository.DeleteOrders("Test87");
            var Nowmodel = repository.FindOrdersByOrderId("Test87");
            Assert.IsTrue(Nowmodel == null);
        }
    }
}