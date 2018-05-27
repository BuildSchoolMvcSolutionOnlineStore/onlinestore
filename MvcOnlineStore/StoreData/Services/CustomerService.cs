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
        public IEnumerable<Customers> CustomerList(string Search, ForPaging Paging)
        {
            IEnumerable<Customers> Data;
            if (String.IsNullOrEmpty(Search))
            {
                Data = repository.GetAll();
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            else
            {
                Data = repository.SearchById(Search);
                Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
                Paging.SetRightPage();
            }
            return Data.OrderBy(x=>x.CustomerID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
    }
}