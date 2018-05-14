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
        public void FindByIdTest()
        {
            var repository = new CustomersRepository();
            var text = repository.FindById("Alice5278");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new CustomersRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var repository = new CustomersRepository();
            var model = new Customer();
            model.CustomerID = "Test";
            model.CustomerPassword = "1234";
            model.CustomerName = "Testabc";
            model.Telephone = 0900000000;
            model.Address = "CHU";
            model.CustomerMail = "Testabc@gmail.com";
            repository.Create(model);
            var text = repository.FindById("Test");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var repository = new CustomersRepository();
            var Oldmodel = repository.FindById("Test");
            Oldmodel.CustomerName = "客戶修改";
            repository.Update(Oldmodel);

            var Newmodel = repository.FindById("Test");
            Assert.IsTrue(Newmodel.CustomerName == "客戶修改");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var repository = new CustomersRepository();
            repository.Delete("Test");
            var text = repository.FindById("Test");
            Assert.IsTrue(text == null);
        }
    }
}