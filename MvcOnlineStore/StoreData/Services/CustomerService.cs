using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using StoreData.Models;
using StoreData.Repositories;
using StoreData.ViewModels.Customer;

namespace StoreData.Services
{
    public class CustomerService
    {
        private CustomersRepository repository = new CustomersRepository();
        private CartRepository cartrepository = new CartRepository();
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
            return Data.OrderBy(x => x.CustomerID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum);
        }
        //註冊方法
        public bool AccountCheck(string Account)
        {
            Customers Search = repository.FindById(Account);
            bool result = (Search == null);
            return result;
        }
        //密碼加密
        public string HashPassword(string Password)
        {
            string saltkey = "fGJgjIThds9554HDA5FDS5A5s5adpwekmhq";
            string saltAndPassword = String.Concat(Password, saltkey);
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashDate = sha1Hasher.ComputeHash(PasswordData);
            string Hashresult = "";
            for (int i = 0; i < HashDate.Length; i++)
            {
                Hashresult += HashDate[i].ToString("x2");
            }
            return Hashresult;
        }
        //加入購物車
        public void CartEvent(string CustomerId, string ProductId, int Quantity)
        {
           var cartdate = cartrepository.FindById(CustomerId);
            foreach (var item in cartdate)
            {
                var newData = new Cart()
                {
                    CustomerID = CustomerId,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                   
                };
                cartrepository.Create(newData);
            }

        }
        //取得購物車內的資料
        public IEnumerable<Cart> GetItemforcart(string CustomerID)
        {
            return cartrepository.GetAll();
        }

        public CustomerView GetAccountByCustomers(string CustomerID)
        {
            var model = repository.FindById(CustomerID);
            return new CustomerView()
            {
                CustomerID = model.CustomerID,
                CustomerPassword = model.CustomerPassword,
                CustomerName = model.CustomerName,
                CustomerMail = model.CustomerMail,
                Address = model.Address,
                Telephone = model.Telephone
            };
        }

        public bool UpdateCustomer(string CustomerID, string CustomerPassword, string CustomerName, string Telephone, string Address, string CustomerMail)
        {
            if(CustomerID != null)
            {
                repository.Update(new Customers
                {
                    CustomerID = CustomerID,
                    CustomerPassword = CustomerPassword,
                    CustomerName = CustomerName,
                    Telephone = Telephone,
                    Address = Address,
                    CustomerMail = CustomerMail
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePassword(string CustomerID, string CustomerPassword)
        {
            if(CustomerID != null)
            {
                repository.UpdatePassword(new Customers
                {
                    CustomerID = CustomerID,
                    CustomerPassword = CustomerPassword
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        //新增會員
        public void CreateCustomer(Customers model)
        {
            repository.Create(model);
        }
    }
}