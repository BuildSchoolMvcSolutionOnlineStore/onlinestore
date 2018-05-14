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
    public class PaymentMethodsRepositoryTests
    {
        [TestMethod()]
        public void FindPaymentMethodsByPaymentMethodsIdTest()
        {
            var repository = new PaymentMethodsRepository();
            var text = repository.FindPaymentMethodsByPaymentMethodsId(1);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllPaymentMethodsTest()
        {
            var repository = new PaymentMethodsRepository();
            var list = repository.GetAllPaymentMethods();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}