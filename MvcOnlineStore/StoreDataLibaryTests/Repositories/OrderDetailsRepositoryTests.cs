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
    public class OrderDetailsRepositoryTests
    {
        [TestMethod()]
        public void FindOrderDetaByOrderId()
        {
            var repository = new OrderDetailsRepository();
            var text = repository.FindOrderDetaByOrderId("DE001");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllOrderDeta()
        {
            var repository = new OrderDetailsRepository();
            var list = repository.GetAllOrderDeta();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void OrderDeta_1_CreateOrderDetaTest()
        {
            var repository = new OrderDetailsRepository();
            var model = new OrderDetails
            {
                OrderID = "DE005",
                ProductID = "A003",
                Quantity = 100,
                Discount = 0.5
            };
            repository.CreateOrderDeta(model);
            var Newmodel = repository.FindOrderDetaByOrderId("DE005");
            Assert.IsTrue(Newmodel != null);
        }

        [TestMethod()]
        public void OrderDeta_2_UpdateOrderDetaTest()
        {
            var repository = new OrderDetailsRepository();
            var Orderdeta = repository.FindOrderDetaByOrderId("DE005");
            Orderdeta.Quantity = 500;
            repository.UpdateOrderDeta(Orderdeta);
            var Newmodel = repository.FindOrderDetaByOrderId("DE005");
            Assert.IsTrue(Newmodel.Quantity == 500);
        }

        [TestMethod()]
        public void OrderDeta_3_DeleteOrderDetaTest()
        {
            var repository = new OrderDetailsRepository();
            repository.DeleteOrderDeta("DE005");
            var Nowmodel = repository.FindOrderDetaByOrderId("DE005");
            Assert.IsTrue(Nowmodel == null);
        }
    }
}