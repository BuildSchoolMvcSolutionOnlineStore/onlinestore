using StoreData.Models;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class AdminService
    {
        private OrdersRepository ordersRepository = new OrdersRepository();
        private CustomersRepository customersRepository = new CustomersRepository();
        public IndexView Dashboard()
        {
            var Data = new IndexView
            {
                MemberCount = customersRepository.GetAllCount(),
                Amount = ordersRepository.GetAmount(),
                OrderCount = ordersRepository.GetNewOrderCount()
            };
            return Data;
        }
    }
}