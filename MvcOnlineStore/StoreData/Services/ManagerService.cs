using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Repositories;
using StoreData.Models;

namespace StoreData.Services
{
    public class ManagerService
    {
        private ManagersRepository managersrepository = new ManagersRepository();
        public void CreateManager(Managers model)
        {
            managersrepository.Create(model);
        }
        public void UpdateManager(Managers model)
        {
            managersrepository.Update(model);
        }
        public void DeleteManager(string ManagerId)
        {
            managersrepository.Delete(ManagerId);
        }
        public Managers FindManagerById(string ManagerId)
        {
            var result = managersrepository.FindById(ManagerId);
            return result;
        }
        public IEnumerable<Managers> GetAllManagers()
        {
            var result = managersrepository.GetAll();
            return result;
        }
    }
}