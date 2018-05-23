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
        public IEnumerable<Orders> OrdersList_Status_0()
        {
            return repository.GetAll().Where((x) => x.Status == 0);
        }
        public IEnumerable<Orders> OrdersList_Status_1()
        {
            return repository.GetAll().Where((x) => x.Status == 1);
        }
        public IEnumerable<Orders> OrdersList_Status_2()
        {
            return repository.GetAll().Where((x) => x.Status == 2);
        }
    }
}