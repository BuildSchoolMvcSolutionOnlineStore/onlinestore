using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Abstracts.PasswordVaildationTools
{
    public interface IHashingProvider
    {
        byte[] ComputeHash(byte[] data);
    }
}