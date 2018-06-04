using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class PayService
    {
        private PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();

        public IEnumerable<PaymentMethods> paymentGetAll()
        {
           var Data = paymentMethodsRepository.GetAll();
            return Data;
        }
        public void Create(PaymentMethods item)
        {
            var Data = paymentMethodsRepository.FindLastPaymentMethodID() + 1;
            item.PaymentMethodID = Data;
            paymentMethodsRepository.Create(item);
        }
        public void Delete(int Id)
        {
            paymentMethodsRepository.Delete(Id);
        }
        public void UpdatePay(PaymentMethods item)
        {
            paymentMethodsRepository.Update(item);
        }
        public PaymentMethods FindById(int Id)
        {
            var Data =  paymentMethodsRepository.FindById(Id);
            return Data;
        }
    } 
}