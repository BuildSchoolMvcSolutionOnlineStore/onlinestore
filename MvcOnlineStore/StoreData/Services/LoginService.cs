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
    }
}