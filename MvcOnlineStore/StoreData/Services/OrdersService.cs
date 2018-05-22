using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class OrdersService
    {
        private OrdersRepository repository = new OrdersRepository();
        public IEnumerable<Orders> OrdersList()
        {
            return repository.GetAll().Where((x) => x.Status == 0);
        }
        
    }
}