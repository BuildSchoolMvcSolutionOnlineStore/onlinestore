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

        [TestMethod()]
        public void CreatePaymentMethodsTest()
        {
            var repository = new PaymentMethodsRepository();
            var model = new PaymentMethods();
            model.PaymentMethodID = 4;
            model.PaymentMethod = "運送方法測試";
            repository.CreatePaymentMethods(model);
            var text = repository.FindPaymentMethodsByPaymentMethodsId(4);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void UpdatePaymentMethodsTest()
        {
            var repository = new PaymentMethodsRepository();
            var Oldmodel = repository.FindPaymentMethodsByPaymentMethodsId(4);
            Oldmodel.PaymentMethod = "已被修改";
            repository.UpdatePaymentMethods(Oldmodel);

            var Newmodel = repository.FindPaymentMethodsByPaymentMethodsId(4);
            Assert.IsTrue(Newmodel.PaymentMethod == "已被修改");
        }

        [TestMethod()]
        public void DeletePaymentMethodsTest()
        {
            var repository = new PaymentMethodsRepository();
            repository.DeletePaymentMethods(4);
            var text = repository.FindPaymentMethodsByPaymentMethodsId(4);
            Assert.IsTrue(text == null);
        }
    }
}