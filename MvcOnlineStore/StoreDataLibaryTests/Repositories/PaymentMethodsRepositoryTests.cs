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
        public void CreatePaymentMethodsTest()
        {
            var repository = new PaymentMethodsRepository();
            var model = new PaymentMethods();
            model.PaymentMethodID = 5;
            model.PaymentMethod = "付款方法測試";
            repository.CreatePaymentMethods(model);
            var text = repository.FindPaymentMethodsByPaymentMethodsId(5);
            Assert.IsTrue(text != null);
        }
    }
}