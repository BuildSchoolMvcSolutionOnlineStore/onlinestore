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
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "INSERT INTO Products VALUES(@ProductID, @CategoryID,@ProductName,@Stock,@UnitPrice,@Size,@Color,@Instructions)",
                model);
            }
        }
        public void Update(Products model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "UPDATE Products SET " +
                "CategoryID = @CategoryID,ProductName = @ProductName,Stock = @Stock,UnitPrice = @UnitPrice," +
                "Size = @Size,Color = @Color,Instructions = @Instructions WHERE ProductID = @ProductID",
                model);
            }
        }
        public void Delete(String ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "DELETE FROM Products WHERE ProductID = @id",
                new
                {
                    id = ProductID
                });
            }
        }

        public Products FindById(string ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductID = @id",
                    new
                    {
                        id = ProductID
                    });
                var product = products.FirstOrDefault();

                return product;
            }
        }
        public IEnumerable<Products> GetAll()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> GetByProductName(string selectString)
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductName LIKE '%'+@str+'%'",
                    new
                    {
                        str = selectString
                    });

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> FindTopByQuantity()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT TOP 3 p.ProductID FROM Products p " +
                    "INNER JOIN OrderDetails od ON od.ProductID = p.ProductID "+
                    "GROUP BY p.ProductID "+
                    "ORDER BY Count(od.Quantity) DESC ");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> OrderByUnitPrice()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products ORDER BY UnitPrice ");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
    }
}
