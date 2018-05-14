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
    public class ManagersRepositoryTests
    {
        [TestMethod()]
        public void Managers_FindByIdTest()
        {
            var repository = new ManagersRepository();
            var text = repository.FindById("MA001");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Managers_GetAllTest()
        {
            var repository = new ManagersRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void Managers_1_CreateManagerTest()
        {
            var repository = new ManagersRepository();
            var model = new Managers();
            model.ManagerID = "Test01";
            model.ManagerName = "test";
            model.ManagerPassword = "AXCD";
            model.ManagerMail = "test@gmail.com";
            repository.Create(model);
            var text = repository.FindById("Test01");
            Assert.IsTrue(text != null);
        }

        [TestMethod()]
        public void Managers_2_UpdateManagerTest()
        {
            var repository = new ManagersRepository();
            var Oldmodel = repository.FindById("Test01");
            Oldmodel.ManagerName = "管理員修改";
            repository.Update(Oldmodel);
            var Newmodel = repository.FindById("Test01");
            Assert.IsTrue(Newmodel.ManagerName == "管理員修改");
        }

        [TestMethod()]
        public void Managers_3_DeleteManagerTest()
        {
            var repository = new ManagersRepository();
            repository.Delete("Test01");
            var text = repository.FindById("Test01");
            Assert.IsTrue(text == null);
        }
    }
}