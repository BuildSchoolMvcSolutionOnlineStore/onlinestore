using StoreData.Models;
using StoreData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Services
{
    public class LoginService
    {
        public string LoginCheck(string managerID, string password)
        {
            var manager = new ManagersRepository();
            var check = manager.FindById(managerID);
            if(check != null)
            {
                if (PasswordCheck(check, password))
                {
                    return "";
                }
                else
                {
                    return "密碼錯誤";
                }
            }
            else
            {
                return "查無此帳號，請去申請";
            }
        }

        public bool PasswordCheck(Managers checkmanager, string password)
        {
            bool result = checkmanager.ManagerPassword.Equals(password);
            return result;
        }

        //前台
        public string CustomerLoginCheck(string CustomerID, string CustomerPassword)
        {
            var customer = new CustomersRepository();
            var check = customer.FindById(CustomerID);
            if(check != null)
            {
                if(CustomerPasswordCheck(check, CustomerPassword))
                {
                    return "";
                }
                else
                {
                    return "密碼錯誤";
                }
            }
            else
            {
                return "查無此帳號，請去申請";
            }
        }

        public bool CustomerPasswordCheck(Customers customers, string password)
        {
            bool result = customers.CustomerPassword.Equals(password);
            return result;
        }
    }
}