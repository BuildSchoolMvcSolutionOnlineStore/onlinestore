using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class DeliveryMethodsRepository
    {
        public void CreateDeliveryMethod(DeliveryMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
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

        public void UpdateDeliveryMethod(DeliveryMethods model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "UPDATE DeliveryMethods SET " + "DeliveryMethod = @DeliveryMethod, Freight = @Freight WHERE DeliveryMethodID = @id",
                new
                {
                    id = model.DeliveryMethodID,
                    DeliveryMethod = model.DeliveryMethod,
                    Freight = model.Freight
                });
            }
        }

        public void DeleteDeliveryMethod(int DeliveryMethodID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "Delete From DeliveryMethods WHERE DeliveryMethodID = @id",
                new
                {
                    id = DeliveryMethodID
                });
            }
        }

        public DeliveryMethods FindDeliveryMethodByDeliveryMethodID(int DeliveryMethodID)
        {          
            DeliveryMethods deliveryMethod = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
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

        public IEnumerable<DeliveryMethods> GetAllDeliveryMethods()
        {
            var deliveryMethodlist = new List<DeliveryMethods>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
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
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var TopAmounts = connection.Query<DeliveryMethods>("SELECT TOP 1 d.DeliveryMethod FROM DeliveryMethods d INNER JOIN Orders o ON d.DeliveryMethodID = o.DeliveryMethodID GROUP BY d.DeliveryMethod ORDER BY COUNT(*) DESC");
                foreach (var item in TopAmounts)
                {
                    deliveryMethod = item.DeliveryMethod;
                }
            }
            return deliveryMethod;
        }
    }
}
