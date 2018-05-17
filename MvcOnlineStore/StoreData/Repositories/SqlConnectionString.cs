using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public static class SqlConnectionString
    {
        private static string serviceIP = "192.168.40.21";
        private static string database = "Shopping";
        private static string userID = "linker";
        private static string password = "19960705";
        //連線字串
        public static string ConnectionString = "Server=" + serviceIP + ";Database="+ database + ";User Id="+ userID + ";Password ="+ password + ";";
    }
}
