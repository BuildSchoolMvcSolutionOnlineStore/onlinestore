using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories.Tests
{
    [TestClass()]
    public class PaymentMethodsRepositoryTests
    {
        [TestMethod()]
        public void FindLastPaymentMethodIDTest()
        {
            PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();
            var num = paymentMethodsRepository.FindLastPaymentMethodID();
            Assert.IsTrue(num > 0 );
        }
    }
}