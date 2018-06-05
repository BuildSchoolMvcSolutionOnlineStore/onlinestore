using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class DeliveryService
    {
        private DeliveryMethodsRepository deliveryMethodsRepository = new DeliveryMethodsRepository();
        
        public IEnumerable<DeliveryMethods> deliveryGetAll()
        {
            var Data = deliveryMethodsRepository.GetAll();
            return Data;
        }
        public void Create(DeliveryMethods item)
        {
            var Data = deliveryMethodsRepository.FindLastDeliveryMethodID() + 1;
            item.DeliveryMethodID = Data;
            deliveryMethodsRepository.Create(item);
        }
        public void Delete(int Id)
        {
            deliveryMethodsRepository.Delete(Id);
        }
        public void UpdateDelivery(DeliveryMethods item)
        {
            deliveryMethodsRepository.Update(item);
        }
        public DeliveryMethods FindById(int Id)
        {
            var Data = deliveryMethodsRepository.FindById(Id);
            return Data;
        }
    }
}