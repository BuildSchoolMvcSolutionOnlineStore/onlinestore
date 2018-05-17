using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Abstracts.PasswordVaildationTools
{
    public interface ISaltStrategy
    {
        string Format(string passwordBody, string salt);
        byte[] Format(byte[] passwordData, byte[] saltData);
    }
}
