using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class DeliveryMethodsRepository
    {
        public void Create(DeliveryMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "INSERT INTO DeliveryMethods VALUES(@DeliveryMethodID, @DeliveryMethod, @Freight)",
                new
                {
                    DeliveryMethodID = model.DeliveryMethodID,
                    DeliveryMethod = model.DeliveryMethod,
                    Freight = model.Freight
                });
            }
        }

        public void Update(DeliveryMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "UPDATE DeliveryMethods SET DeliveryMethod = @DeliveryMethod , Freight = @Freight WHERE DeliveryMethodID = @id",
                new
                {
                    id = model.DeliveryMethodID,
                    DeliveryMethod = model.DeliveryMethod,
                    Freight = model.Freight
                });
            }
        }

        public void Delete(int DeliveryMethodID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "Delete From DeliveryMethods WHERE DeliveryMethodID = @id",
                new
                {
                    id = DeliveryMethodID
                });
            }
        }

        public DeliveryMethods FindById(int DeliveryMethodID)
        {          
            DeliveryMethods deliveryMethod = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var deliveryMethods = connection.Query<DeliveryMethods>(
                    "SELECT * FROM DeliveryMethods WHERE DeliveryMethodID = @id",
                    new
                    {
                        id = DeliveryMethodID
                    });

                foreach (var item in deliveryMethods)
                {
                    if (item.DeliveryMethodID != 0)
                        deliveryMethod = item;
                }
            }
            return deliveryMethod;
        }

        public IEnumerable<DeliveryMethods> GetAll()
        {
            var deliveryMethodlist = new List<DeliveryMethods>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var deliveryMethods = connection.Query<DeliveryMethods>(
                    "SELECT * FROM DeliveryMethods");

                foreach (var item in deliveryMethods)
                {
                    deliveryMethodlist.Add(item);
                }
            }
            return deliveryMethodlist;
        }

        public string FindTopByDeliveryMethodID()
        {
            string deliveryMethod = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var TopAmounts = connection.Query<DeliveryMethods>("SELECT TOP 1 d.DeliveryMethod FROM DeliveryMethods d INNER JOIN Orders o ON d.DeliveryMethodID = o.DeliveryMethodID GROUP BY d.DeliveryMethod ORDER BY COUNT(*) DESC");
                foreach (var item in TopAmounts)
                {
                    deliveryMethod = item.DeliveryMethod;
                }
            }
            return deliveryMethod;
        }
        public int FindLastDeliveryMethodID()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var deliveryMethods = connection.Query<int>(
                    "select top 1 DeliveryMethodID from DeliveryMethods order by DeliveryMethodID desc");
                return deliveryMethods.FirstOrDefault();
            }

        }
    }
}
