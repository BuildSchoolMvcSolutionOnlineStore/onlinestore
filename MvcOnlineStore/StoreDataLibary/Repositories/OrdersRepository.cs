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
    public class OrdersRepository
    {
        public void CreateOrders(Orders model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute("INSERT INTO Orders VALUES(@OrderID ,@CustomerID, @OrderDate, @ShippedDate, @PaymentMethodID, @DeliveryMethodID)",
                    model);
            }
        }

        public void UpdateOrders(Orders model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "UPRATE Orders SET @CustomerID, @OrderDate, @ShippedDate, @PaymentMethodID, @DeliveryMethodID WHERE OrderID = @id",
                new
                {
                    id = model.OrderID,
                    OrderID = model.OrderID,
                    CustomerID = model.CustomerID,
                    OrderDate = model.OrderDate,
                    ShippedDate = model.ShippedDate,
                    PaymentMethodID = model.PaymentMethodID,
                    DeliveryMethodID = model.DeliveryMethodID
                });
            }
        }

        public void DeleteOrders(string OrderID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "Delete From Orders WHERE OrderID = @id",
                    new
                    {
                        id = OrderID
                    });
            }
        }

        public Orders FindOrdersByOrderId(string OrderId)
        {
            Orders order = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var orders = connection.Query<Orders>(
                    "SELECT * FROM Orders WHERE OrdersID = @id",
                    new
                    {
                        id = OrderId
                    });
                foreach(var item in orders)
                {
                    if (item.OrderID != null)
                        order = item;
                }
            }
            return order;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            var orderslist = new List<Orders>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var orders = connection.Query<Orders>(
                    "SELECT * FROM Orders");
                foreach(var item in orders)
                {
                    orderslist.Add(item);
                }
            }
            return orderslist;
        }
    }
}
