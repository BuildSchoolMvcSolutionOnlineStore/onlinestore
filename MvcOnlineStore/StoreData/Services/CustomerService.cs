using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreData.Models;
using StoreData.Repositories;

namespace StoreData.Services
{
    public class CustomerService
    {
        private CustomersRepository repository = new CustomersRepository();
        public IEnumerable<Customers> CustomerList(string Id)
        {
            if(String.IsNullOrEmpty(Id))
            {
                return repository.GetAll();
            }
            else
            {
                return repository.SearchById(Id);
            }
        }
    }
}