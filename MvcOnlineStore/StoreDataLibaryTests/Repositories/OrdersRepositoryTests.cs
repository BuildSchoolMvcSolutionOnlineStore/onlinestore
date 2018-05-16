﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var text = repository.FindOrdersByOrderId("DE001");
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
        public void Orders_1_CreateOrdersTest()
        {
            var repository = new OrdersRepository();
            var model = new Orders
            {
                OrderID = "Test87",
                CustomerID = "liouli",
                OrderDate = new DateTime(2018, 12, 12),
                ShippedDate = new DateTime(2018, 1, 1),
                PaymentMethodID = 1,
                DeliveryMethodID = 2,
                Status = 0
            };
            repository.CreateOrders(model);
            var search = repository.FindOrdersByOrderId("Test87");
            Assert.IsTrue(search != null);
        }

        [TestMethod()]
        public void Orders_2_UpdateOrdersTest()
        {
            var repository = new OrdersRepository();
            var Ordersmodel = repository.FindOrdersByOrderId("Test87");
            Ordersmodel.CustomerID = "Jhon8868";
            repository.UpdateOrders(Ordersmodel);
            var Newmodel = repository.FindOrdersByOrderId("Test87");
            Assert.IsTrue(Newmodel.CustomerID == "Jhon8868");
        }

        [TestMethod()]
        public void Orders_3_DeleteOrdersTest()
        {
            var repository = new OrdersRepository();
            repository.DeleteOrders("Test87");
            var Nowmodel = repository.FindOrdersByOrderId("Test87");
            Assert.IsTrue(Nowmodel == null);
        }
    }
}