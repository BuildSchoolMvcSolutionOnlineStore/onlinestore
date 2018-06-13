using Dapper;
using StoreData.Models;
using StoreData.ViewModels.Customer;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class OrdersRepository
    {
        public void Create(Orders model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO Orders VALUES(@OrderID ,@CustomerID, @OrderDate, @ShippedDate, @PaymentMethodID, @DeliveryMethodID,@Status)",
                    model);
            }
        }

        public void Update(Orders model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                "UPDATE Orders SET CustomerID = @CustomerID, OrderDate = @OrderDate, ShippedDate = @ShippedDate, PaymentMethodID = @PaymentMethodID, DeliveryMethodID = @DeliveryMethodID, Status = @Status WHERE OrderID = @OrderID", model);
            }
        }

        public void Delete(string OrderID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "Delete From Orders WHERE OrderID = @id",
                    new
                    {
                        id = OrderID
                    });
            }
        }

        public Orders FindById(string OrderId)
        {
            Orders order = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var orders = connection.Query<Orders>(
                    "SELECT * FROM Orders WHERE OrderID = @id",
                    new
                    {
                        id = OrderId
                    });
                foreach (var item in orders)
                {
                    if (item.OrderID != null)
                    {
                        order = item;
                    }
                }
            }
            return order;
        }

        public IEnumerable<Orders> GetAll()
        {
            var orderslist = new List<Orders>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var orders = connection.Query<Orders>(
                    "SELECT * FROM Orders");
                foreach (var item in orders)
                {
                    orderslist.Add(item);
                }
            }
            return orderslist;
        }

        public IEnumerable<AdminOrder> GetAll_Admin()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var list = connection.Query<AdminOrder>(
                    "SELECT o.OrderID," +
                    "(SELECT CustomerName FROM Customers WHERE CustomerID = o.CustomerID) AS CustomerName," +
                    "o.OrderDate,o.ShippedDate," +
                    "(SELECT PaymentMethod FROM PaymentMethods WHERE PaymentMethodID = o.PaymentMethodID) AS PaymentMethod," +
                    "(SELECT DeliveryMethod FROM DeliveryMethods WHERE DeliveryMethodID = o.DeliveryMethodID) AS DeliveryMethod," +
                    "(SELECT SUM(od.Quantity * p.UnitPrice ) FROM OrderDetails od INNER JOIN Products p ON p.ProductID = od.ProductID WHERE od.OrderID = o.OrderID) AS Amount," +
                    "o.Status," +
                    "(SELECT COUNT (*) FROM [Messages] WHERE OrderID = o.OrderID AND Reply IS NOT NULL ) As Count " +
                    "FROM Orders o"
                    );
                return list;
            }
        }
        public IEnumerable<AdminOrder> SearchById_Admin(string selectString)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var list = connection.Query<AdminOrder>(
                    "SELECT o.OrderID," +
                    "(SELECT CustomerName FROM Customers WHERE CustomerID = o.CustomerID) AS CustomerName," +
                    "o.OrderDate,o.ShippedDate," +
                    "(SELECT PaymentMethod FROM PaymentMethods WHERE PaymentMethodID = o.PaymentMethodID) AS PaymentMethod," +
                    "(SELECT DeliveryMethod FROM DeliveryMethods WHERE DeliveryMethodID = o.DeliveryMethodID) AS DeliveryMethod," +
                    "(SELECT SUM(od.Quantity * p.UnitPrice ) FROM OrderDetails od INNER JOIN Products p ON p.ProductID = od.ProductID WHERE od.OrderID = o.OrderID) AS Amount," +
                    "o.Status," +
                    "(SELECT COUNT (*) FROM [Messages] WHERE OrderID = o.OrderID AND Reply IS NOT NULL ) As Count " +
                    "FROM Orders o " +
                    "WHERE o.OrderID LIKE '%'+@str+'%'",
                    new
                    {
                        str = selectString
                    });
                return list;
            }
        }
        //取得新訂單的數量
        public int GetNewOrderCount()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var count = connection.Query<int>(
                    "SELECT COUNT(*) FROM Orders WHERE Status = 0"
                    );
                return count.FirstOrDefault();
            }
        }

        //取得完成訂單的總金額
        public int GetAmount()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                try
                {
                    var amount = connection.Query<int>(
                        "SELECT SUM(od.Quantity * p.UnitPrice ) " +
                        "FROM OrderDetails od " +
                        "INNER JOIN Products p ON p.ProductID = od.ProductID " +
                        "INNER JOIN Orders o On o.OrderID = od.OrderID " +
                        "WHERE o.Status = 3 "
                        );
                    return amount.FirstOrDefault();
                }
                catch
                {
                    return 0;
                }

            }
        }
        public string GetNewId()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var id = connection.Query<string>("SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC");
                return id.FirstOrDefault();
            }
        }
        public IEnumerable<CustomerOrder> GetAll_Customer(string customerId)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var order = connection.Query<CustomerOrder>(
                    "SELECT o.OrderID," +
                    "o.OrderDate,o.ShippedDate," +
                    "(SELECT PaymentMethod FROM PaymentMethods WHERE PaymentMethodID = o.PaymentMethodID) AS PaymentMethod," +
                    "(SELECT DeliveryMethod FROM DeliveryMethods WHERE DeliveryMethodID = o.DeliveryMethodID) AS DeliveryMethod," +
                    "(SELECT SUM(od.Quantity * p.UnitPrice ) FROM OrderDetails od INNER JOIN Products p ON p.ProductID = od.ProductID WHERE od.OrderID = o.OrderID) AS Amount," +
                    "o.Status " +
                    "FROM Orders o " +
                    "WHERE o.CustomerID = @CustomerId", new
                    {
                        CustomerId = customerId
                    });
                return order;
            }
        }
        public IEnumerable<CustomerOrder> SearchById_Customer(string customerId,string orderId)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var order = connection.Query<CustomerOrder>(
                    "SELECT o.OrderID," +
                    "o.OrderDate,o.ShippedDate," +
                    "(SELECT PaymentMethod FROM PaymentMethods WHERE PaymentMethodID = o.PaymentMethodID) AS PaymentMethod," +
                    "(SELECT DeliveryMethod FROM DeliveryMethods WHERE DeliveryMethodID = o.DeliveryMethodID) AS DeliveryMethod," +
                    "(SELECT SUM(od.Quantity * p.UnitPrice ) FROM OrderDetails od INNER JOIN Products p ON p.ProductID = od.ProductID WHERE od.OrderID = o.OrderID) AS Amount," +
                    "o.Status " +
                    "FROM Orders o " +
                    "WHERE o.CustomerID = @CustomerId AND o.OrderID = @OrderId", new
                    {
                        CustomerId = customerId,
                        OrderId = orderId
                    });
                return order;
            }
        }
    }
}
