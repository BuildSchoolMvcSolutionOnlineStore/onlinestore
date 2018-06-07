using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreData.Repositories
{
    public class CartRepository
    {
        public void Create(Cart model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO Cart VALUES(@CustomerID,@ProductID,@Quantity)",
                new
                {
                    customerID = model.CustomerID,
                    productID=model.ProductID,
                    Quantity=model.Quantity
                    
                });
            }
        }
        public void Update(Cart model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "UPDATE Cart SET " +
                    "ProductID = @ProductID, Quantity = @Quantity WHERE CustomerID = @CustomerID AND ProductID = @ProductID", model);
            }
        }
        public void Delete(String CustomerID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "Delete From Cart WHERE CustomerID = @id",
                    new
                    {
                        id = CustomerID
                    });
            }
        }
        public Cart FindById(string CustomerID)
        {
            Cart cart = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var cartdata = connection.Query<Cart>(
                    "SELECT * FROM Cart WHERE CustomerID = @id",
                    new
                    {
                        id = CustomerID
                    });
                foreach (var item in cartdata)
                {
                    if (item.CustomerID != null)
                        cart = item;
                }
            }
            return cart;
        }
        public IEnumerable<Cart> GetAll()
        {
            var Cartlist = new List<Cart>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var carts = connection.Query<Cart>(
                    "SELECT * FROM Cart");

                foreach (var item in carts)
                {
                    Cartlist.Add(item);
                }
            }
            return Cartlist;
        }




    }
}