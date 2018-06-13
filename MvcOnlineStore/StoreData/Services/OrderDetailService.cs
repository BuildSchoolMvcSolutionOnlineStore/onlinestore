using StoreData.Models;
using StoreData.Repositories;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class OrderDetailService
    {
        private OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
        public IEnumerable<AdminOrderDetail> GetAdminOrders(string Id)
        {
            var list = orderDetailsRepository.FindById_Admin(Id);
            return list;
        }
    }
}