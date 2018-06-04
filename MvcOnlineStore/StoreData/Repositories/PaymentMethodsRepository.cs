using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class PaymentMethodsRepository
    {
        public void Create(PaymentMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO PaymentMethods VALUES(@PaymentMethodID, @PaymentMethod)",
                    new
                    {
                        PaymentMethodID = model.PaymentMethodID,
                        PaymentMethod = model.PaymentMethod
                    });
            }

        }

        public void Update(PaymentMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("UPDATE PaymentMethods SET PaymentMethod = @PaymentMethod WHERE PaymentMethodID = @id",
                    new
                    {
                        id = model.PaymentMethodID,
                        PaymentMethod = model.PaymentMethod
                    });
            }
        }
        public void Delete(int PaymentMethodID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("Delete From PaymentMethods WHERE PaymentMethodID = @id",
                    new
                    {
                        id = PaymentMethodID
                    });
            }
        }

        public PaymentMethods FindById(int PaymentMethodID)
        //單筆資料查詢
        {
            PaymentMethods paymentMethod = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var paymentMethods = connection.Query <PaymentMethods> ("SELECT * FROM PaymentMethods WHERE PaymentMethodID = @id",
                    new
                    {
                        id = PaymentMethodID
                    });

                foreach (var item in paymentMethods)
                {
                    if (item.PaymentMethodID != 0)
                        paymentMethod = item;
                }
            }
            return paymentMethod;
        }
        public IEnumerable<PaymentMethods> GetAll()
        {
            var paymentMethodlist = new List<PaymentMethods>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<PaymentMethods>(
                    "SELECT * FROM PaymentMethods");

                foreach (var item in products)
                {
                    paymentMethodlist.Add(item);
                }
            }
            return paymentMethodlist;
        }

        public IEnumerable<PaymentMethods> FindTopByPaymentMethodID()
        {
            var paymentMethodlist = new List<PaymentMethods>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var paymentMethods = connection.Query<PaymentMethods>(
                    "select p.PaymentMethod from PaymentMethods as p inner join Orders as o on  p.PaymentMethodID = o.PaymentMethodID group by p.PaymentMethod order by count(*) desc");

                foreach (var item in paymentMethods)
                {
                    paymentMethodlist.Add(item);
                }
            }
            return paymentMethodlist;
        }
        public int FindLastPaymentMethodID()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var paymentMethods = connection.Query<int>(
                    "select top 1 PaymentMethodID from PaymentMethods order by PaymentMethodID desc");
                return paymentMethods.FirstOrDefault();
            }

        }
            
    }
}
