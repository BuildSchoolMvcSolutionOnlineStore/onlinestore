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
        public int UpdateProductQuantity(string orderId,string prdocutId,int quantity)
        {
            var data = orderDetailsRepository.FindById(orderId, prdocutId);
            var diff = quantity - data.Quantity;
            data.Quantity = quantity;
            orderDetailsRepository.Update(data);
            return diff;
        }
        public void DeleteOrderProduct(string orderId, string prdocutId)
        {
            orderDetailsRepository.Delete(orderId, prdocutId);
        }
    }
}