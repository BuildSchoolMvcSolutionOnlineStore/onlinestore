using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories.Tests
{
    [TestClass()]
    public class CartRepositoryTests
    {
        private CartRepository repository = new CartRepository();
        [TestMethod()]
        public void Cart_1_CreateTest()
        {
            var model = new Cart();
            model.CustomerID = "Test";
            model.ProductID = "A005";
            model.Quantity = 5;
            repository.Create(model);
            var text = repository.FindById("Test");
            Assert.IsTrue(text != null);

        }

        [TestMethod()]
        public void Cart_2_UpdateTest()
        {

            var Cartdeta = repository.FindById("Test").FirstOrDefault();
            Cartdeta.Quantity = 30;
            repository.Update(Cartdeta);
            var Newmodel = repository.FindById("Test").FirstOrDefault();
            Assert.IsTrue(Newmodel.Quantity == 30);


        }

        [TestMethod()]
        public void Cart_3_DeleteTest()
        {
            repository.Delete("Test");
            var Nowmodel = repository.FindById("Test");
            Assert.IsTrue(Nowmodel == null);

        }

        [TestMethod()]
        public void FindByIdTest()
        {
            var text = repository.FindById("Alison");
            Assert.IsTrue(text != null);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
            
        }
    }
}