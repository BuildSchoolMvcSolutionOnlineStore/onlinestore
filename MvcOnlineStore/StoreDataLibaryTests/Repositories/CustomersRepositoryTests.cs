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
    public class CustomersRepositoryTests
    {
        [TestMethod()]
        public void Customers_FindByIdTest()
        {
            var repository = new CustomersRepository();
            var text = repository.FindCustomerByCustomerId("Jhon8868");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Customers_GetAllTest()
        {
            var repository = new CustomersRepository();
            var list = repository.GetAllCustomers();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void Customers_1_CreateTest()
        {
            var repository = new CustomersRepository();
            var model = new Customers();
            model.CustomerID = "Test";
            model.CustomerPassword = "1234";
            model.CustomerName = "Testabc";
            model.Telephone = 0900000000;
            model.Address = "CHU";
            model.CustomerMail = "Testabc@gmail.com";
            repository.CreateCustomer(model);
            var text = repository.FindCustomerByCustomerId("Test");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Customers_2_UpdateTest()
        {
            var repository = new CustomersRepository();
            var Oldmodel = repository.FindCustomerByCustomerId("Test");
            Oldmodel.CustomerName = "fjhdf";
            repository.UpdateCustomer(Oldmodel);

            var Newmodel = repository.FindCustomerByCustomerId("Test");
            Assert.IsTrue(Newmodel.CustomerName == "fjhdf");
        }

        [TestMethod()]
        public void Customers_3_DeleteTest()
        {
            var repository = new CustomersRepository();
            repository.DeleteCustomer("Test");
            var text = repository.FindCustomerByCustomerId("Test");
            Assert.IsTrue(text == null);
        }

        [TestMethod()]
        public void FindTopAmountByCustomerIdTest()
        {
            var repository = new CustomersRepository();
            var list = repository.FindTopAmountByCustomerId();
            Assert.IsTrue(list != null);
        }
    }
}