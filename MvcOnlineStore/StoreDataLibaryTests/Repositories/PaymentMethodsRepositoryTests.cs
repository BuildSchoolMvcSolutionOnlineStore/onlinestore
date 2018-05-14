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
    public class PaymentMethodsRepositoryTests
    {
        [TestMethod()]
        public void FindByIdTest()
        {
            var repository = new PaymentMethodsRepository();
            var text = repository.FindById(1);
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new PaymentMethodsRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count()>0);
        }
    }
}