﻿using Dapper;
using StoreData.Models;
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
    public class OrderDetailsRepository
    {
        public void Create(OrderDetails model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO OrderDetails VALUES(@OrderID ,@ProductID,@Quantity,@Discount)", model);
            }
        }
        public void Update(OrderDetails model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("UPDATE OrderDetails SET Quantity = @Quantity, Discount =@Discount WHERE OrderID = @OrderID AND ProductID = @ProductID", model);
            }
        }
        public void Delete(string OrderID,string ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "Delete From OrderDetails WHERE OrderID = @OrderID AND ProductID = @ProductID",
                    new
                    {
                        OrderID,
                        ProductID
                    });
            }
        }
        public OrderDetails FindById(string OrderId,string ProductId)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var data = connection.Query<OrderDetails>(
                    "SELECT * FROM OrderDetails WHERE OrderID = @OrderId AND ProductID = @ProductId",
                    new {
                        OrderId, ProductId
                    });
                return data.FirstOrDefault();
            }
        }
        public OrderDetails FindOrderDetaByOrderId(string OrderId)
        //單筆資料查詢
        {
            OrderDetails orderDetails = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var orderdeta = connection.Query<OrderDetails>(
                    "SELECT * FROM OrderDetails WHERE OrderID = @id",
                    new
                    {
                        id = OrderId
                    });
                foreach (var item in orderdeta)
                {
                    if (item.OrderID != null)
                    {
                        orderDetails = item;
                    }
                }
            }
            return orderDetails;
        }
        public IEnumerable<OrderDetails> GetAllOrderDeta()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var orderdeta = connection.Query<OrderDetails>("SELECT * FROM OrderDetails");
                return orderdeta;
            }
        }
        public IEnumerable<AdminOrderDetail> FindById_Admin(string Id)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var list = connection.Query<AdminOrderDetail>(
                    "SELECT od.ProductID," +
                    "(SELECT Path FROM Products WHERE od.ProductID = ProductID) AS Path," +
                    "(SELECT ProductName FROM Products WHERE od.ProductID = ProductID) AS ProductName," +
                    "(SELECT UnitPrice FROM Products WHERE od.ProductID = ProductID) AS UnitPrice," +
                    "od.Quantity " +
                    "FROM OrderDetails od " +
                    "WHERE od.OrderID = @Id", new { Id });
                return list;
            }
        }
    }
}
