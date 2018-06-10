using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StoreData.Repositories
{
    public static class SqlConnectionString
    {
        //連線字串
        public static string ConnectionString()
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLAZURECONNSTR_DbConnection")))
            {
                return Environment.GetEnvironmentVariable("SQLAZURECONNSTR_DbConnection");
            }
            else
            {
                //return ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                //return "Server=buildschool.database.windows.net;Database=bs-team7;User Id=bsteam7;Password=@bsTp77G#;";
                return "Server=192.168.50.20;Database=Shopping;User Id=linker;Password=19960705;";
            }
        }
    }
}
