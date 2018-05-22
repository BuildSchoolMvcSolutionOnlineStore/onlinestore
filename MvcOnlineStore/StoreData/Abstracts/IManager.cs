using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Abstracts
{
    public interface IManager
    {
        void Create(Managers model);
        void Update(Managers model);
        void Delete(string ManagerID);
        Managers FindById(string ManagerID);
        IEnumerable<Managers> GetAll();
    }
}
