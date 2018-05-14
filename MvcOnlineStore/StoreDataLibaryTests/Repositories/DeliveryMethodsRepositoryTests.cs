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
    public class DeliveryMethodsRepositoryTests
    {
        [TestMethod()]
        public void FindDeliveryMethodByDeliveryMethodIDTest()
        {
            var repository = new DeliveryMethodsRepository();
            var text = repository.FindDeliveryMethodByDeliveryMethodID("1");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllDeliveryMethodsTest()
        {
            var repository = new DeliveryMethodsRepository();
            var list = repository.GetAllDeliveryMethods();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
