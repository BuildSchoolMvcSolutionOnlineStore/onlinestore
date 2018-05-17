using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Abstracts.PasswordVaildationTools
{
    public interface IPasswordRule
    {
        bool Validate(string password);
        string Generate();
    }
}
