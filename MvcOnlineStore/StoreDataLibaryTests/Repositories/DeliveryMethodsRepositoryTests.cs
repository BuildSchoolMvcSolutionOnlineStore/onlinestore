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
    public class DeliveryMethodsRepositoryTests
    {
        [TestMethod()]
        public void DeliveryMethods_FindByIdTest()
        {
            var repository = new DeliveryMethodsRepository();
            var text = repository.FindDeliveryMethodByDeliveryMethodID(1);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void DeliveryMethods_GetAllTest()
        {
            var repository = new DeliveryMethodsRepository();
            var list = repository.GetAllDeliveryMethods();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void DeliveryMethods_1_CreateDeliveryMethodTest()
        {
            var repository = new DeliveryMethodsRepository();
            var model = new DeliveryMethods();
            model.DeliveryMethodID = 5;
            model.DeliveryMethod = "萊爾富";
            model.Freight = 70;
            repository.CreateDeliveryMethod(model);
            var text = repository.FindDeliveryMethodByDeliveryMethodID(5);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void DeliveryMethods_2_UpdateDeliveryMethodTest()
        {
            var repository = new DeliveryMethodsRepository();
            var Oldmodel = repository.FindDeliveryMethodByDeliveryMethodID(5);
            Oldmodel.DeliveryMethod = "OK";
            repository.UpdateDeliveryMethod(Oldmodel);

            var Newmodel = repository.FindDeliveryMethodByDeliveryMethodID(5);
            Assert.IsTrue(Newmodel.DeliveryMethod == "OK");
        }

        //[TestMethod()]
        //public void DeliveryMethods_3_DeleteDeliveryMethodTest()
        //{
        //    var repository = new DeliveryMethodsRepository();
        //    repository.DeleteDeliveryMethod(5);
        //    var text = repository.FindDeliveryMethodByDeliveryMethodID(5);
        //    Assert.IsTrue(text == null);
        //}
    }
}
